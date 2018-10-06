using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepFaith : PassiveItem {
	
	void Start() {
		base.Start();
		this.pickUpText = "Your faith shields you";
	}

	void Update() {
		base.Update();
	}


	public override void OnEquip() {
		Properties.ToggleFlag("faithShield", true);
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("faithShield", !true);
	}
	
	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Properties.ToggleFlag("faithShield", true);
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 				Destroy(transform.parent);
	// 				Destroy(this.gameObject);
	// 			} else {

	// 			}
	// 		} else {
	// 			Properties.ToggleFlag("faithShield", true);
	// 			if (!spawned) {
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 			Destroy(this.gameObject);
	// 		}
	// 	} 
	// }
}
