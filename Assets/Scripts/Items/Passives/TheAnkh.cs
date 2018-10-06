using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAnkh : PassiveItem {

	void Start() {
		base.Start();
		this.pickUpText = "Eternal life?";
	}

	void Update() {
		base.Update();
	}


	public override void OnEquip() {

	}

	public override void OnUnequip() {

	}

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && Properties.GetInstance().devilCounter < 2) {
	// 		Destroy(gameObject);
	// 		Properties.ModifyExtraLives(1);
	// 		Properties.IncreaseDevilItemsCounter();
	// 		Properties.ToggleFlag("devilishItem", true);
	// 		Properties.ToggleFlag("ankh", true);
	// 		/*dodawanie do ekwipunku*/
	// 		if (!spawned) {
	// 			GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 			Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			spawned = true;
	// 		}	
			
	// 	} 

	// }


}
