using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelicFeather : PassiveItem {

	


	void Start() {
		base.Start();
	}

	void Update() {
		base.Update();
	}



	public override void OnEquip() {
		Properties.ToggleFlag("isFlying", true);
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("isFlying", false);
	}





	// void Start() {
	// 	price = 5;
	// 	switch (GameManager.levelTag) {
	// 		case 1: break;
	// 		case 2:

	// 			break;
	// 		case 3:

	// 			break;
	// 		case 4:

	// 			break;
	// 		case 5:

	// 			break;
	// 		case 6:

	// 			break;
	// 		case 7:

	// 			break;
	// 		case 8:

	// 			break;
	// 		case 9:

	// 			break;
	// 	}
	// }

	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		/*dodawanie do ekwipunku*/
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ToggleFlag("isFlying", true);
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Destroy(gameObject);
	// 				Destroy(transform.parent);
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 			} else {
	// 					/* miejsce na obsługę braku pinionszkuf */
	// 			}	
	// 		} else {
	// 			Destroy(gameObject);
	// 			if (!spawned) {
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 			Properties.ToggleFlag("isFlying", true);
	// 		}
	// 	}
	// }
}
