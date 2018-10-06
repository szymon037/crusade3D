using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheThirdEye : PassiveItem {

	void Start() {
		base.Start();
		this.pickUpText = "Gaze into the iris";
	}

	void Update() {
		base.Update();
	}


	public override void OnEquip() {
		Properties.ToggleFlag("thirdEye", true);
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("thirdEye", !true);
	}
	
	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (transform.position != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Properties.ToggleFlag("thirdEye", true); //ustawiamy flagę na true, żeby móc wykonać dodatkowy atak
	// 				Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed * 1.4f); 
	// 				Properties.SetMaxHealth(Properties.GetInstance().maxHealth - 10);
	// 				Properties.SetMaxFaith(Properties.GetInstance().maxFaith - 10);
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
	// 			Properties.ToggleFlag("thirdEye", true); //ustawiamy flagę na true, żeby móc wykonać dodatkowy atak
	// 			Properties.SetAttackSpeed(Properties.GetInstance().attackSpeed * 1.4f); 
	// 			Properties.SetMaxHealth(Properties.GetInstance().maxHealth - 10);
	// 			Properties.SetMaxFaith(Properties.GetInstance().maxFaith - 10);
	// 			/*dodawanie do ekwipunku*/
	// 			if (!spawned) {
	// 				GameObject kys = Instantiate(toSpawn, new Vector3(0f, 0f, 0f), Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 			Destroy(gameObject);
	// 		}
			
	// 	} 
	// }
}
