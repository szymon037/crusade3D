using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyHorseshoe : PassiveItem {

	public int luckModifier = 2;


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

	// void OnTriggerEnter2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Properties.ModifyLuck(luckModifier);
	// 				if (!spawned) {
	// 					spawned = true;
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 				Destroy(transform.parent);
	// 				Destroy(gameObject);
	// 			} else {
	// 				/* obsługa braku pinionszkuf */
	// 			}
	// 		} else {
	// 			Properties.ModifyLuck(luckModifier);
	// 			Destroy(gameObject);
	// 			if (!spawned) {
	// 				spawned = true;
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			}
	// 		}
	// 	}
	// }
}
