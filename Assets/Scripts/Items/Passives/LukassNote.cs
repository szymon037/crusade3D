using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukassNote : PassiveItem {

	void Start() {
		base.Start();
	}

	void Update() {
		base.Update();
	}



	public override void OnEquip() {
		Properties.ToggleFlag("hiddenMap", true);
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("hiddenMap", false);
	}
	


	// void OnTriggerEnter2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				if (!spawned) {
	// 					spawned = true;
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				}
	// 				Properties.ToggleFlag("hiddenMap", true);
	// 				ItemList.RemoveRelic(this.gameObject);
	// 				Destroy(transform.parent);
	// 				Destroy(gameObject);
	// 			} else {
	// 				/* obsługa braku pinionszkuf */
	// 			}
	// 		} else {
	// 			if (!spawned) {
	// 				spawned = true;
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			}
	// 			Properties.ToggleFlag("hiddenMap", true);
	// 			Destroy(gameObject);
	// 		}
	// 	}
	// }
}
