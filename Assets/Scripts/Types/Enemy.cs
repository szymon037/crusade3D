using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public float health 			= 0f;
	public float damage 			= 0f;
	public float speed 				= 0f;
	public float knockback			= 0f;
	public float faithRecovery 	 	= 0f;
	public float bleedTimer 		= 0f;
	public float onFireTimer 		= 0f;
	public float poisonTimer 		= 0f;
	public float electricityTimer 	= 0f;
	public float damnationTimer 	= 0f;
	public float blindTimer 		= 0f;
	public float hitTimer 			= 0f;
	public bool bleeding 			= false;
	public bool onFire 				= false;
	public bool poisoned 			= false;
	public bool electrified			= false;
	public bool damned 				= false;
	public bool blinded 			= false;
	public bool isHit 				= false;
	public Rigidbody body			= null;
	public Transform player 		= null;
	private float tempSpeed			= 0f;
	private float tempDmg			= 0f;
	//public int[] weights 			= null;
	/*#if UNITY_EDITOR 

	void OnDrawGizmos() {
		int size = System.Enum.GetNames(typeof(AttackType)).Length;
		if (weights == null) {
			weights = new int[size];
		} else {
			if (size != weights.Length) {
				int[] temp = new int[size];
				if (size > weights.Length) {
					for(int i = 0; i < weights.Length; ++i) {
						temp[i] = weights[i];
					}
				}
				else if (size < weights.Length) {
					for(int i = 0; i < size; ++i) {
						temp[i] = weights[i];
					}
				}
				weights = temp;
			}
		}
	}

	#endif*/

	//public static List<GameObject> pickUps = new List<GameObject>();
	void Awake() {

	}

	void Update() {
		

	}

	public virtual void Die() {
		Properties.ModifyFaith((int)faithRecovery);// += faithRecovery;
		Destroy(this.gameObject);
	}

	public virtual void ReceiveDamage(float damage) {
		isHit = true;
		hitTimer = 0.55f;
		health -= (int)damage;
		body.AddForce(-knockback * (player.position - this.transform.position), ForceMode.Impulse);
	}
}
