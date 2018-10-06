using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRainbow : PassiveItem {

	void Start() {
		base.Start();
		this.pickUpText = "Wait... what?";
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
	// 		Properties.ToggleFlag("devilishItem", true); //diabelski przedmiot, więc ustawiamy flagę od zebrania go na true
	// 		Properties.SetSpeed(Properties.GetInstance().speed * 2f);
	// 		Properties.IncreaseDevilItemsCounter();
	// 		/*dodawanie do ekwipunku*/
	// 		if (!spawned) {
	// 			GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 			Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 			spawned = true;
	// 		}
	// 	}
	// }
}
