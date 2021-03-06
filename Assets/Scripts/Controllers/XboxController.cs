﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxController : MonoBehaviour {

	public enum ControlsChoice {
		defaultChoice = 0,
		secondChoice = 1,
		thirdChoice = 2
	}

	public PlayerBehaviour playerBehaviour = null;
	public Rigidbody body = null;
	public Vector3 moveDirection 		= new Vector3(0f, 0f, 0f);

	private int numberOfAttack 			= 0;	//licznik ataku - po 3ech atakach cooldown

	void Start () {
		playerBehaviour = GetComponent<PlayerBehaviour>();
		body = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float x = Properties.GetInstance().flags["confused"] ? -Input.GetAxisRaw("GamepadHorizontal") : Input.GetAxisRaw("GamepadHorizontal");
		float z = Properties.GetInstance().flags["confused"] ? -Input.GetAxisRaw("GamepadVertical") : Input.GetAxisRaw("GamepadVertical");

		if (!Properties.GetInstance().flags["isRolling"] && playerBehaviour.attackDelay <= 0f /*playerBehaviour.attackingTimer <= 0f*/) {
			moveDirection.x = x * Properties.GetInstance().speed;
			moveDirection.z = z * Properties.GetInstance().speed;
			body.velocity = moveDirection;
		} else if (!Properties.GetInstance().flags["isRolling"]) {
			body.velocity = Vector3.zero;
		}

		playerBehaviour.lookDirection.x = x;
		playerBehaviour.lookDirection.z = z;
		playerBehaviour.lookDirection = playerBehaviour.lookDirection.normalized;

		if (Input.GetKeyDown("joystick button 2") && playerBehaviour.attackDelay <= 0f && playerBehaviour.numberOfAttack < 3) {													//joystick button 2 teoretycznie X na xboxie
			playerBehaviour.Attack(Properties.GetInstance().flags["thirdEye"] ? true : false, /*playerBehaviour.lookDirection,*/ Properties.GetInstance().attackRange);
		}

		if (Input.GetKeyDown("joystick button 1") && !Properties.GetInstance().flags["isRolling"] && playerBehaviour.rollTimer <= 0f) {		//joystick button 1 teoretycznie O 
			playerBehaviour.Dodge();
		}

		if (Input.GetKeyDown("joystick button 4") && Properties.GetInstance().holyWater > 0) {
			Properties.ModifyHolyWaterCount(-1);
			playerBehaviour.holyWaterTimer = 15f;
		}		
	}					
}
