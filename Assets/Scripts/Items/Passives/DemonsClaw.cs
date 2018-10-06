using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonsClaw : PassiveItem {

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
	// 		Properties.SetMaxHealth(Properties.GetInstance().maxHealth - 20f);// 		-= 20f;
	// 		Properties.ModifyDamage(0.35f);// 		= (Properties.GetInstance().baseDmg * 0.35f);
	// 		Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed / 3); 	// /= 3;
	// 		Properties.SetMaxFaith(Properties.GetInstance().maxFaith - 20f);// 		-= 20f;
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
