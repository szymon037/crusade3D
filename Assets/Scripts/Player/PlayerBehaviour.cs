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
	public float attackAnimationTimer	= 0f;
	public float numberOfAttackTimer	= 0f;		//numberOfAttack musi być wyzerowany też po odpowiednim czasie
	public float rollSpeed 			  	= 15f;
	public float rollDistance 		  	= 1.5f;
	public float attackDelay 			= 0f;

	//public Vector2 rollTargetPosition 	= Vector2.zero;
	public Vector3 rollTargetPosition 		= new Vector3(0f, 0f, 0f);
	//public Vector2 lookDirection 		= new Vector2(0f, 0f);
	public Vector3 lookDirection 			= new Vector3(0f, 0f, 0f);
	//public onUse[] itemEffects 			= new onUse[System.Enum.GetNames(typeof(Properties.ActiveItem)).Length];
	//public Dictionary<string, bool> itemEffectsFlags = new Dictionary<string, bool>();
	//public ContactFilter2D filter 		= new ContactFilter2D();
	//public RaycastHit2D[] hits 			= new RaycastHit2D[35];  
	public RaycastHit[] hits 				= new RaycastHit[35];  
	public string[] gamepadnames 			= null;
	public Rigidbody playerBody 			= null;
	public PS4Controller ps4 				= null;
	public XboxController xbox 				= null;
	public Keyboard keyboard 				= null;
	public AnimationScript animationScript 	= null;
	//public Crosshair crosshair			= null;

	private WaitForSeconds waitTime			= new WaitForSeconds(0.15f);

    public bool gamepadConnected = false;
    public int numberOfAttack = 0;			//jeśli równy 3, wtedy cooldown

	public Vector3 colliderCenter			= new Vector3(0f, 0f, 0f);
	private BoxCollider playerCollider;
	private RaycastHit playerHit ; 
	private int j = 0;

	private bool isHit 						= false;
    private Vector3 p 						= new Vector3(0f, 0f, 0f);		//wektor przechowujący pozycję celownika na płaszczyźnie kamery (w świecie gry)
    public 	Vector3 attackDirection			= new Vector3(0f, 0f, 0f);		//wektor przechowujący pozycję, na którą wskazuje celownik w świecie gry
    public Vector3 attackDirectionOnClick 	= new Vector3(0f, 0f, 0f);		//wektor przechowujący pozycję, na którą wskazuje celownik w świecie gry w chwili ataku
	public Camera 	cam 					= null;
	public Vector3 	attackOrigin 			= Vector3.zero;
	private int 	mask 					= -1;
	public Vector3 newScale					= Vector3.zero;

	public bool isAttacking					= false;
	public bool isAttackAnimRunning			= false;

    void Start () {
	//	healthDisplay.text = "Health : " + Properties.GetInstance().health.ToString();
		//attackDelay = 0.1f;//Properties.GetInstance().attackSpeed;
		//healthBar.value = Properties.GetInstance().health;
		//filter.useDepth = true;
		//filter.SetDepth(0.5f, 1f);
		gamepadnames = Input.GetJoystickNames();
		playerBody = gameObject.GetComponent<Rigidbody>();
		ps4 = gameObject.GetComponent<PS4Controller>();
		xbox = gameObject.GetComponent<XboxController>();
		keyboard = gameObject.GetComponent<Keyboard>();
		animationScript = gameObject.GetComponent<AnimationScript>();
		StartCoroutine("InputCheck");

		playerCollider = GetComponent<BoxCollider>();
		//newScale = new Vector3(0.5f, 0.5f, 1f);


	}
	
	void Update () {
               
        //timery

		//liczenie pozycji celownika na płaszczyźnie kamery
		p = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

		
		

		if(!gamepadConnected)
			attackDirection = new Vector3(p.x-this.transform.position.x, 0f, p.y+p.z-this.transform.position.z);
		else
			attackDirection = new Vector3(Input.GetAxisRaw("GamepadHorizontal"), 0f, Input.GetAxisRaw("GamepadVertical"));
			
		//Debug.Log("kierunek ataku: " + attackDirection);
		//pozycja na którą wskazuje celownik w świecie gry
		
		attackOrigin = this.transform.position + playerCollider.center; 
		Debug.Log("attackDirection: " + attackDirection + " attackDirectionOnClick: " + attackDirectionOnClick);
		//Debug.Log(transform.localScale);

		//Debug.Log("attackDelay: " + attackDelay);

		

        if (attackDelay > 0f) {
	        attackDelay -= Time.deltaTime;

	        if(attackDelay <= 0f) {
	        	isAttacking = false;

	        	//if(numberOfAttack >= 3)
	        		//numberOfAttack = 0;
	        }

        }

        if (numberOfAttackTimer > 0) {
			numberOfAttackTimer -= Time.deltaTime;
			if( animationScript.isMoving == 0f && attackDelay < 0f )
				playerBody.AddForce(1.1f * attackDirectionOnClick.normalized, ForceMode.Impulse);
			if(numberOfAttackTimer <= 0f){
				numberOfAttack = 0;
				isAttackAnimRunning = false;
			}
		}

		if (rollTimer > 0f) {
			rollTimer -= Time.deltaTime;
			playerBody.velocity *= 0.65f;
		}
		if (rollTimer <= 0f) Properties.ToggleFlag("isRolling", false);

		if (holyWaterTimer > 0f) holyWaterTimer -= Time.deltaTime;

		/*if (attackingTimer > 0f) {
			attackingTimer -= Time.deltaTime;
			//playerBody.velocity *= 0.65f;	//przeniesione do Keyboard
			if(attackingTimer <= 0f)
				isAttacking = false;
		}*/
		
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

	public void Attack(bool bonus, float range) { 

		if(attackDirection != Vector3.zero)
			attackDirectionOnClick = attackDirection;
		isAttacking = true;
		++numberOfAttack;
		attackDelay = 0.375f;	//0.375 - długość odgrywania 6 klatek ataku
		numberOfAttackTimer = 0.9375f;

		if (numberOfAttack < 3) {
			playerBody.velocity *= 0f;
		} /*else if (numberOfAttack == 3) {
			//attackDelay = 0.375f;		//0.9375 - długość odgrywania całej animacji ataku
			//numberOfAttackTimer = 0.9375f;
		}*/



		if(	Physics.BoxCast(
		attackOrigin,
		transform.localScale*0.5f, 		
		//newScale, //nowa skala - do atakowania kilku przeciwników na raz (?)
		//attackDirectionOnClick.normalized,			//tu jest attackDirectionOnClick zamiast attackDirection, bo gdy jest podłączony pad i nie wychyla się gałki to attackDirection = 0.
		((attackDirection.x != 0) && (attackDirection.z != 0)) ? attackDirection.normalized : animationScript.lastMove,
		out playerHit,
		transform.rotation,
		range,
		mask))
		{
		//Debug.Log("HIT" + j);
		++j;
		//Debug.Log("Hit: " + playerHit.collider.name);
		isHit = true;

		}
		else isHit = false;
		Debug.Log("Hit: " + playerHit.transform);


			//Debug.Log(attackDirection.x + attackDirection.y + attackDirection.z);
		Debug.DrawRay(new Vector3(attackOrigin.x, attackOrigin.y, attackOrigin.z), attackDirection, Color.blue, 2f);
		
		playerBody.AddForce(2f * attackDirectionOnClick.normalized, ForceMode.Impulse);			//ta linijka w jakiś sposób wyjebuje rolanda w prawie że kosmos //albo i nie

		//Debug.DrawRay(transform.position, attackDirection, Color.red, 1f);
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
							Attack(false, /*attackDirection,*/ range);
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

	void OnDrawGizmos()
    {
       

        //Check if there has been a hit yet
        if (isHit)
        {
        	 Gizmos.color = Color.green;
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(attackOrigin, attackDirection.normalized * playerHit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(attackOrigin + attackDirection.normalized * playerHit.distance, transform.localScale*0.5f);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
        	Gizmos.color = Color.red;
        	Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        	 Gizmos.color = Color.green;
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(attackOrigin, attackDirection.normalized * 100f);
            //Draw a cube at the maximum distance
            //Gizmos.DrawWireCube(this.transform.position + crosshair.attackDirection * 100f, transform.localScale);
        }
    }
}
