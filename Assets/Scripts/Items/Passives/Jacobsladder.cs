using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jacobsladder : PassiveItem {

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
	// 		Properties.ToggleFlag("damnation", true);// = true;
	// 		Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed / 1.15f);
	// 		Properties.ModifyDamage(-0.1f);// -= (Properties.GetInstance().baseDmg * 0.1f);
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
