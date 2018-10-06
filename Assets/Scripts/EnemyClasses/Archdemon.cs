using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archdemon : RangedEnemy {
	
	public int summonDelay 	 	= 0;
	public GameObject minion 	= null;
	public GameObject fireball  = null;
	public Transform shootPoint = null;
	public float offset 		= 0;
	public float distance 		= 0f;
	private GameObject target   = null;
	private float fireballTimer = 0f;
	private float attackTimer   = 0f;
	private float summonTimer   = 0f;

	void Start() {
		fireballTimer = 2f;
		attackTimer = 2f;
		summonTimer = (float)((int)Random.Range(10f, 21f));
		target = GameObject.FindGameObjectWithTag("Player");
	}



	void Update() {



		if (fireballTimer > 0f) {
			fireballTimer -= Time.deltaTime;
		}
 
		if (fireballTimer <= 0f && Vector2.Distance(transform.position, target.transform.position) <= 1f) {		//Vector2.Distance == Vector3.Distance (tak przynajmniej podpowiada dokumentacja)
			Shoot();
			fireballTimer = 2f;
		}

		if (summonTimer > 0f) {
			summonTimer -= Time.deltaTime;
		}

		if (summonTimer <= 0f) {
			Summon();
			summonTimer = (float)((int)Random.Range(10f, 21f));
		}

		if (attackTimer > 0f) {
			attackTimer -= Time.deltaTime;
		}

		if (attackTimer <= 0f && Vector2.Distance(transform.position, target.transform.position) <= 0.5f) {
			attackTimer = 1.5f;
			Melee();
		}

	}


	void Summon() {
		Vector3 temp = new Vector3(offset, 0f, 0f);
		GameObject minion1 = Instantiate(minion, transform.position - temp, Quaternion.identity) as GameObject;
		GameObject minion2 = Instantiate(minion, transform.position + temp, Quaternion.identity) as GameObject;
	}

	void Shoot() {
		GameObject kys = Instantiate(fireball, shootPoint.position, Quaternion.identity) as GameObject;
		kys.GetComponent<FireballBehaviour>().direction = (transform.position - kys.GetComponent<FireballBehaviour>().player.position).normalized;
	}

	void Melee() {
		Vector3 temp = target.transform.position;
		LayerMask mask = -1;
		RaycastHit2D hit = Physics2D.BoxCast(
			transform.position,
			Vector2.one * 0.1f,
			0f,
			temp,
			5f, 
			mask,
			0f,
			0.2f
		);

		if (hit.transform != null && hit.transform.gameObject.tag == "Player" && Properties.GetInstance().flags["isHit"] == false) {
			Properties.GetInstance().health -= (int)damage;
			Properties.GetInstance().flags["isHit"] = true;
		}
	}
}
