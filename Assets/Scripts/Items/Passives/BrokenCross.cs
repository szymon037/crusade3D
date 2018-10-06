using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCross : PassiveItem {

	void Start() {
		base.Start();
		this.pickUpText = "They will pay...";
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
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Destroy(transform.parent);
	// 				Destroy(gameObject);
	// 				Properties.ModifyDamage(0.5f);
	// 				Properties.ModifyFaith(-10);
	// 				/*dodawanie do ekwipunku*/
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 			} else {
	// 				/* obsługa braku pinionszkuf*/
	// 			}
	// 		} else {
	// 			Destroy(gameObject);
	// 			//Properties.GetInstance().damage 	+= (Properties.GetInstance().baseDmg * 0.5f);
	// 			//Properties.GetInstance().faith 		-= 10f;
	// 			Properties.ModifyDamage(0.5f);
	// 			Properties.ModifyFaith(-10);
	// 			/*dodawanie do ekwipunku*/
	// 			if (!spawned) {
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 		}
			
	// 	}
	// }
}
