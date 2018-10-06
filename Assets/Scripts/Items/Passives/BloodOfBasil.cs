using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// WŁAŚCIWOŚCI
// Speed up (a little)
// Health up
// Life Leech
public class BloodOfBasil : PassiveItem {

	public int healthUp = 0;
	public float speedUp = 0f;

	void Start() {
		base.Start();
	}

	void Update() {
		base.Update();
	}

	public override void OnEquip() {
		Properties.ToggleFlag("lifeLeech", true);
		Properties.ModifyMaxHealth(this.healthUp);
		Properties.ModifySpeed(this.speedUp);
	}

	public override void OnUnequip() {
		Properties.ToggleFlag("lifeLeech", false);
		Properties.ModifyMaxHealth(-this.healthUp);
		Properties.ModifySpeed(-this.speedUp);
	}



	// void OnTriggerStay2D(Collider2D other) {
	// 	if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);// -= this.price;
	// 				Properties.SetMaxHealth(Properties.GetInstance().maxHealth + Properties.GetInstance().maxHealth * 0.2f);// += (Properties.GetInstance().maxHealth * 0.2f);
	// 				Properties.ToggleFlag("lifeLeech", true);
	// 				Properties.ModifySpeed(Properties.GetInstance().speed * 0.1f);
	// 				Destroy(transform.parent);
	// 				Destroy(gameObject);
	// 				ItemList.RemoveUnholy(this.gameObject);
	// 				if (!spawned) {
	// 					GameObject temp = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 					Inventory.addToInventory(temp.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 			} else {
	// 				/*miejsce na obsługę braku pinionszkuf*/
	// 			}
	// 		} else {
	// 			Destroy(gameObject);
	// 			Properties.SetMaxHealth(Properties.GetInstance().maxHealth + Properties.GetInstance().maxHealth * 0.2f);
	// 			Properties.ToggleFlag("lifeLeech", true);
	// 			Properties.ModifySpeed(Properties.GetInstance().speed * 0.1f);
	// 			/*dodawanie do ekwipunku*/
	// 			if (!spawned) {
	// 				GameObject temp = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject;
	// 				Inventory.addToInventory(temp.GetComponent<RectTransform>());
	// 				spawned = true;
	// 			}
	// 		}
	// 	}
	// }
}
