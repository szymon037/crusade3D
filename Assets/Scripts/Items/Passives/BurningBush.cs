using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningBush : PassiveItem {

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
	// 		if (transform.parent != null) {
	// 			if (Properties.GetInstance().money >= this.price) {
	// 				Properties.ModifyMoneyCount(-this.price);
	// 				Destroy(transform.parent);
	// 				Destroy(this.gameObject);
	// 				Properties.ToggleFlag("fireAtt", true);//	= true;
	// 				Properties.ModifyDamage(0.1f);// 			+= (Properties.GetInstance().baseDmg * 0.1f);
	// 				/*dodawanie do ekwipunku*/
	// 				if (!spawned) {
	// 					GameObject kys = Instantiate(toSpawn, Vector3.zero, Quaternion.identity, list) as GameObject; 
	// 					Inventory.addToInventory(kys.GetComponent<RectTransform>());
	// 					spawned = true;
	// 				}
	// 				ItemList.RemoveRelic(this.gameObject);
	// 			} else {
	// 				/*obsługa braku pinionszkuf*/
	// 			}

	// 		} else {
	// 			Destroy(gameObject);
	// 			Properties.GetInstance().flags["fireAtt"] 	= true;
	// 			Properties.GetInstance().damage 			+= (Properties.GetInstance().baseDmg * 0.1f);
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
