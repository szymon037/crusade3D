using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : PassiveItem {

	void Start() {
		base.Start();
	}

	void Update() {
		base.Update();
	}


	public override void OnEquip() {
		Properties.ToggleFlag("devilishItem", true);
		Properties.ModifyDamage(2f);
		Properties.IncreaseDevilItemsCounter();
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("devilishItem", false);
		Properties.ModifyDamage(-2f);
		Properties.DecreaseDevilItemsCounter();
	}

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && Properties.GetInstance().devilCounter < 2) {
	// 		Destroy(gameObject);
	// 		Properties.ModifyDamage(2f);// 				+= (Properties.GetInstance().baseDmg * 2f);
	// 		Properties.IncreaseDevilItemsCounter();
	// 		Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed / 2); 		//	-= (Properties.GetInstance().attackSpeed / 2);
	// 		Properties.ToggleFlag("devilishItem", true);
	// 		/*dodawanie do ekwipunku*/
	// 		if (!spawned) {
	// 			GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 			Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			spawned = true;
	// 		}
	// 	}
	// }
}