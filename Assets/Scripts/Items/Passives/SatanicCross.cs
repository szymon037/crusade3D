﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanicCross : PassiveItem {

	void Start() {
		base.Start();
	}

	void Update() {
		base.Update();
	}



	public override void OnEquip() {
		
	}

	public override void OnUnequip() {

	}

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && Properties.GetInstance().devilCounter < 2) {
	// 		Properties.IncreaseDevilItemsCounter();
	// 		/*dodawanie do ekwipunku*/
	// 		if (!spawned) {
	// 			GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 			Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			spawned = true;
	// 		}
	// 		Destroy(gameObject);
	// 	}
	// }
}
