using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StPeterChains : PassiveItem {

	void Start() {
		base.Start();
		this.pickUpText = "Burden of sins...";
	}

	void Update() {
		base.Update();
	}


	public override void OnEquip() {

	}

	public override void OnUnequip() {

	}

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Properties.SetSpeed(Properties.GetInstance().speed / 2);
	// 				Properties.ModifyProtection(20);
	// 				/*dodawanie do ekwipunku*/
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 				Destroy(transform.parent);
	// 				Destroy(gameObject);		
	// 			} else {
	// 				/* obsługa braku pinionszkuf */
	// 			}
	// 		} else {
	// 			Properties.SetSpeed(Properties.GetInstance().speed / 2);
	// 			Properties.ModifyProtection(20);
	// 			/*dodawanie do ekwipunku*/
	// 			if (!spawned) {
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 			Destroy(gameObject);
	// 		}
	// 	}
	// }
}
