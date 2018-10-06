using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stigmata : PassiveItem {

	void Start() {
		base.Start();
		this.pickUpText = "Is this... blood?";
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
	// 				Properties.SetMaxHealth(Properties.GetInstance().maxHealth + 30);
	// 				Properties.SetMaxFaith(Properties.GetInstance().maxFaith + 30);
	// 				Properties.ModifyHealth(30);
	// 				Properties.ModifyFaith(30);
	// 				Properties.ModifySpeed(-Properties.GetInstance().speed * 0.15f);
	// 				Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed * 1.15f);
	// 				/*dodawanie do ekwipunku*/
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 				Destroy(transform.parent);
	// 				Destroy(gameObject);
	// 			} else {
	// 				/* obsługa braku pinionszkuf */
	// 			}
	// 		} else {
	// 			Properties.SetMaxHealth(Properties.GetInstance().maxHealth + 30);
	// 			Properties.SetMaxFaith(Properties.GetInstance().maxFaith + 30);
	// 			Properties.ModifyHealth(30);
	// 			Properties.ModifyFaith(30);
	// 			Properties.ModifySpeed(-Properties.GetInstance().speed * 0.15f);
	// 			Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed * 1.15f);
	// 			/*dodawanie do ekwipunku*/
	// 			if (!spawned) {
	// 				GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 			Destroy(gameObject);
	// 		}
	// 	}
	// }
}
