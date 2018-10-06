using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WŁAŚCIWOŚCI
//Ustawia flagę 

public class GateKeepersBlessing : PassiveItem {

	void Start() {
		base.Start();
	}

	void Update() {
		base.Update();
	}


	public override void OnEquip() {
		Properties.ToggleFlag("gatekeeper", true);
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("gatekeeper", !true);
	}

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		/*dodawanie do ekwipunku*/
	// 		if (!spawned) {
	// 			GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 			Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			spawned = true;
	// 		}
	// 		Properties.ToggleFlag("gatekeeper", true);
	// 		Destroy(gameObject);
	// 	}
	// }
}
