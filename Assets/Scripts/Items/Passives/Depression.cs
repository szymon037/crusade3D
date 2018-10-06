using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depression : PassiveItem {

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
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (!spawned) {
	// 			spawned = true;
	// 			GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 			Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 		}
	// 		Destroy(gameObject);
	// 	}
	// }
}
