using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

	public enum ControlsChoice {
		defaultChoice = 0,
		secondChoice = 1,
		thirdChoice = 2
	}

	public PlayerBehaviour playerBehaviour 	= null;
	public Crosshair crosshair				= null;
	public Rigidbody body 					= null;
	public Vector3 moveDirection 			= new Vector3(0f, 0f, 0f);

	
	void Start () {
		playerBehaviour = GetComponent<PlayerBehaviour>();
		body = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float x = Properties.GetInstance().flags["confused"] ? -Input.GetAxisRaw("Horizontal") 	: Input.GetAxisRaw("Horizontal");
		float z = Properties.GetInstance().flags["confused"] ? -Input.GetAxisRaw("Vertical") 	: Input.GetAxisRaw("Vertical");

		if (!Properties.GetInstance().flags["isRolling"] && playerBehaviour.attackDelay <= 0f /*playerBehaviour.attackingTimer <= 0f*/) {
			float tempSpeed = Properties.GetInstance().speed;
			if (x != 0 && z != 0) tempSpeed /= 1.41f;
			moveDirection.x = x * tempSpeed * 0.707f;
			moveDirection.z = z * tempSpeed;
			body.velocity = moveDirection;
		}

		playerBehaviour.lookDirection.x = x;
		playerBehaviour.lookDirection.z = z;
		playerBehaviour.lookDirection = playerBehaviour.lookDirection.normalized;

		
		if (Input.GetKeyDown(KeyCode.Space) && !Properties.GetInstance().flags["isRolling"] && playerBehaviour.rollTimer <= 0f) {
			playerBehaviour.Dodge();
		}
		
		if (Input.GetMouseButtonDown(0) && playerBehaviour.attackDelay <= 0f && playerBehaviour.numberOfAttack < 3) {
			/*playerBehaviour.attackDirectionOnClick = playerBehaviour.attackDirection;
			playerBehaviour.isAttacking = true;
			playerBehaviour.breakAttackAnimation = true;
			++playerBehaviour.numberOfAttack;*/
		
			playerBehaviour.Attack(Properties.GetInstance().flags["thirdEye"] ? true : false, /*crosshair.attackDirection,*/ Properties.GetInstance().attackRange);
			/*if (playerBehaviour.numberOfAttack == 3) {
				playerBehaviour.attackDelay = 0.375f;		//0.9375 - długość odgrywania całej animacji ataku
				playerBehaviour.numberOfAttackTimer = 0.9375f;
			} else if(playerBehaviour.numberOfAttack < 3){
				playerBehaviour.attackDelay = 0.375f;	//0.375 - długość odgrywania 6 klatek ataku
				playerBehaviour.playerBody.velocity *= 0.65f;
				playerBehaviour.numberOfAttackTimer = 0.9375f;
			}*/
		}
	}	
}
