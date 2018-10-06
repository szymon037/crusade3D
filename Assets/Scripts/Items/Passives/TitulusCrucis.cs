using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitulusCrucis : PassiveItem {

	void Start() {

	} 

	void Update() {

	}


	public override void OnEquip() {

	}

	public override void OnUnequip() {
		
	}

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		/*dodawanie do ekwipunku*/
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				Destroy(transform.parent);
	// 				Destroy(this.gameObject);
	// 				ItemList.RemoveRelic(this.gameObject);
	// 			} else {
	// 				/* obsługa braku pinionszkuf */
	// 			}
	// 		} else {
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
