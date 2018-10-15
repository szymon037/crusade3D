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

	private int numberOfAttack 				= 0;	//licznik ataku - po 3ech atakach cooldown
	
	void Start () {
		playerBehaviour = GetComponent<PlayerBehaviour>();
		body = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float x = Properties.GetInstance().flags["confused"] ? -Input.GetAxisRaw("Horizontal") : Input.GetAxisRaw("Horizontal");
		float z = Properties.GetInstance().flags["confused"] ? -Input.GetAxisRaw("Vertical") : Input.GetAxisRaw("Vertical");

		if (!Properties.GetInstance().flags["isRolling"] && playerBehaviour.attackingTimer <= 0f) {
			float tempSpeed = Properties.GetInstance().speed;
			if (x != 0 && z != 0) tempSpeed /= 1.41f;
			moveDirection.x = x * tempSpeed;
			moveDirection.z = z * tempSpeed;
			body.velocity = moveDirection;
		}

		playerBehaviour.lookDirection.x = x;
		playerBehaviour.lookDirection.z = z;
		playerBehaviour.lookDirection = playerBehaviour.lookDirection.normalized;

		
		if (Input.GetKeyDown(KeyCode.Space) && !Properties.GetInstance().flags["isRolling"] && playerBehaviour.rollTimer <= 0f) {
			playerBehaviour.Dodge();
		}
		
		if (Input.GetMouseButtonDown(0) && playerBehaviour.attackDelay <= 0f) {
			playerBehaviour.Attack(Properties.GetInstance().flags["thirdEye"] ? true : false, /*crosshair.attackDirection,*/ Properties.GetInstance().attackRange);
			if (++numberOfAttack >= 3) {
				playerBehaviour.attackDelay = 0.50f;
				numberOfAttack = 0;
			} else playerBehaviour.attackDelay = 0.18f;
			playerBehaviour.attackingTimer = 0.25f;
		}
	}

	
}
