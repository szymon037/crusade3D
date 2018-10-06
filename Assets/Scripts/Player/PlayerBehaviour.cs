using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour {

	//public delegate void onUse();
	public Text healthDisplay;
	public Slider healthBar;

	public bool blindingHit				= false;
	public bool xboxGamePad 			= false;
	public bool dualshock 				= false;
	
	public float activeItemTimer		= 0f;
	public float holyWaterTimer 		= 0f;
	public float blessingTimer 			= 0f;
	public float rollTimer 				= 0f;
	public float hitTimer 				= 0f;
	public float confuseTimer			= 0f;
	public float attackingTimer 		= 0f;
	public float rollSpeed 			  	= 15f;
	public float rollDistance 		  	= 1.5f;
	public float attackDelay 			= 0f;

	//public Vector2 rollTargetPosition 	= Vector2.zero;
	public Vector3 rollTargetPosition 	= new Vector3(0f, 0f, 0f);
	//public Vector2 lookDirection 		= new Vector2(0f, 0f);
	public Vector3 lookDirection 		= new Vector3(0f, 0f, 0f);
	//public onUse[] itemEffects 			= new onUse[System.Enum.GetNames(typeof(Properties.ActiveItem)).Length];
	//public Dictionary<string, bool> itemEffectsFlags = new Dictionary<string, bool>();
	//public ContactFilter2D filter 		= new ContactFilter2D();
	//public RaycastHit2D[] hits 			= new RaycastHit2D[35];  
	public RaycastHit[] hits 			= new RaycastHit[35];  
	public string[] gamepadnames 		= null;
	public Rigidbody playerBody 		= null;
	public PS4Controller ps4 			= null;
	public XboxController xbox 			= null;
	public Keyboard keyboard 			= null;

	private WaitForSeconds waitTime		= new WaitForSeconds(0.15f);

    public bool gamepadConnected = false;
    private int numberOfAttack = 0;			//jeśli równy 3, wtedy cooldown

	public Vector3 colliderCenter		= new Vector3(0f, 0f, 0f);
	private BoxCollider playerCollider;
	private RaycastHit playerHit ; 


    void Start () {
	//	healthDisplay.text = "Health : " + Properties.GetInstance().health.ToString();
		attackDelay = 0.1f;//Properties.GetInstance().attackSpeed;

		//healthBar.value = Properties.GetInstance().health;
		//filter.useDepth = true;
		//filter.SetDepth(0.5f, 1f);
		gamepadnames = Input.GetJoystickNames();
		playerBody = gameObject.GetComponent<Rigidbody>();
		ps4 = gameObject.GetComponent<PS4Controller>();
		xbox = gameObject.GetComponent<XboxController>();
		keyboard = gameObject.GetComponent<Keyboard>();
		StartCoroutine("InputCheck");

		playerCollider = GetComponent<BoxCollider>();




	}
	
	void Update () {
               
        //timery

		//Debug.Log(playerCollider.center);
		

        if (attackDelay > 0f) attackDelay -= Time.deltaTime;

		if (rollTimer > 0f) {
			rollTimer -= Time.deltaTime;
			playerBody.velocity *= 0.65f;
		}
		if (rollTimer <= 0f) Properties.ToggleFlag("isRolling", false);

		if (holyWaterTimer > 0f) holyWaterTimer -= Time.deltaTime;

		if (attackingTimer > 0f) {
			attackingTimer -= Time.deltaTime;
			playerBody.velocity *= 0.65f;
		}
	}

	IEnumerator InputCheck() {
		while (true) {
			GamepadCheck();
			yield return waitTime;
		}
	}

	void GamepadCheck() {
		gamepadnames = Input.GetJoystickNames();
		if (gamepadnames != null && gamepadnames.Length > 0) {
			for (int i = 0; i < gamepadnames.Length; ++i) {
				if (!string.IsNullOrEmpty(gamepadnames[i])) {
                    gamepadConnected = true;
					if (gamepadnames[i].Contains("Xbox 360") || gamepadnames[i].Contains("Xbox One")) {
						xboxGamePad = true;
					} else if (string.Compare("Wireless Controller", gamepadnames[i]) == 0) {
						dualshock = true;
					} else {
						dualshock = false;
						xboxGamePad = false;
					}
				} else {
					dualshock = false;
					xboxGamePad = false;
                    gamepadConnected = false;
				}
			}
		}
		if (dualshock && !xboxGamePad) {
			ps4.enabled = true;
			xbox.enabled = false;
			keyboard.enabled = false;
		} else if (xboxGamePad && !dualshock) {
			xbox.enabled = true;
			ps4.enabled = false;
			keyboard.enabled = false;
		} else {
			xbox.enabled = false;
			ps4.enabled = false;
			keyboard.enabled = true;
		}
	}

	/* metoda do atakowania */

	public void Dodge() {
		rollTimer = 0.75f;
		Properties.ToggleFlag("isRolling", true);
		playerBody.AddForce(lookDirection * rollSpeed, ForceMode.Impulse);
		lookDirection = Vector3.zero;
	}

	public void Attack(bool bonus, Vector2 direction, float range) { 
		//LayerMask mask = -1;
		/*Physics2D.BoxCast(
			transform.position,
			Vector2.one * 0.4f,
			0f,
			direction,
			filter,
			hits,
			range
			);*/

			Physics.BoxCast(
			playerCollider.center,
			
			transform.localScale * 0.5f, 		//w opisie w dokumentacji ma być połowa (halfExtents), ale w przykładzie jest całość, bez *0.5f
			direction,
			out playerHit,
			transform.rotation,
			range
		);

		Debug.DrawRay(playerCollider.center+transform.position, direction, Color.blue, 1f);
		
		playerBody.AddForce(1.5f * direction, ForceMode.Impulse);

		Debug.DrawRay(transform.position, direction, Color.red, 1f);
		foreach (RaycastHit obj in hits) {										//!!!
			if (obj.transform != null) {
				if (obj.transform.gameObject.CompareTag("Enemy")) {
					GameObject enemy = (GameObject)obj.transform.gameObject;
					Debug.Log(enemy.name);
					float ctrl = Properties.GetInstance().damage;

					/* jeśli aktywowaliśmy wodę święconą to przemnażamy dmg przez 1.2 */
					if (holyWaterTimer > 0) {
						ctrl *= 1.2f;
					}	

					/* jeśli wskrzesiliśmy się przy pomocy przedmiotu "The Ankh" to zwiększa nasz dmg o 60% */
					if (Properties.GetInstance().flags["ankhResurrection"]) {
						ctrl += (ctrl * 0.6f);
					}

					/* jeśli mamy "Blood of Basil" to jest szansa na leczenie przy uderzeniu */
					if (Properties.GetInstance().flags["lifeLeech"]) {
						if (Random.value <= 0.05f) {
							Properties.GetInstance().health += (ctrl / 15);
						}
					}

					/* jeśli mamy item podpalający to to odpowiada za podpalanie */
					if (Properties.GetInstance().flags["fireAtt"]) {
						if (Random.value <= 0.1f) {
							enemy.GetComponent<Enemy>().onFire = true;
						}
					}

					/* tak samo jak z krwawieniem */
					if (Properties.GetInstance().flags["bleed"]) {
						if (Random.value <= 0.1f) {
							enemy.GetComponent<Enemy>().bleeding = true;
						}
					}
					
					/* jeśli mamy przedmiot "The Third Eye" to mamy 15% szans na dodatkowy atak */
					if (Properties.GetInstance().flags["thirdEye"]) {
						if (bonus && Random.value <= 0.15f) {
							Attack(false, direction, range);
						}
					}
					/* */
					if (Properties.GetInstance().flags["damnation"]) {

					}

					/* jeśli mamy przedmiot "Greed" to zwiększa nasz dmg za każdą monetkę */
					if (Properties.GetInstance().flags["greed"]) {
						ctrl += (Properties.GetInstance().money * 0.1f);
					}

					/*tak samo jak z Greed, tylko zwiększa za klucze */ 
					if (Properties.GetInstance().flags["gatekeeper"]) {
						ctrl += (Properties.GetInstance().keys * 0.05f);
					}
					/* oślepianie przeciwników przy ciosie */
					if (blindingHit) {
						blindingHit = false;
						enemy.GetComponent<Enemy>().blinded = true;
					}
					/*odbieranie przeciwnikom hp */
					enemy.GetComponent<Enemy>().ReceiveDamage(ctrl);
					//enemy.GetComponent<Enemy>().hitTimer = 0.3f;
				}
			}
		}
		
	}

	public void Skill() {
		blindingHit = true;
		if (Properties.GetInstance().flags["isTransformed"]) {
			
		}
	}
}
