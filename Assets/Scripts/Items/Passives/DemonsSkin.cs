using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonsSkin : PassiveItem {

	
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
	// 		Properties.ModifyProtection(15);// += 15;
	// 		Properties.SetSpeed(Properties.GetInstance().speed - 0.4f);// -= 0.4f;
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
