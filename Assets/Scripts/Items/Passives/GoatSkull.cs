using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatSkull : PassiveItem {

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
	// 		Properties.ModifyProtection(35);//		+= 35;
	// 		Properties.ModifyDamage(0.05f);// 			+= (Properties.GetInstance().baseDmg * 0.05f);
	// 		Properties.ToggleFlag("goatsSkull", true);//= true;
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
