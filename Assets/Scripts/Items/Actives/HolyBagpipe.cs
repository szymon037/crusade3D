using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBagpipe : ActiveItem {

	void Start() {
		this.ID = 1;
		this.faithConsumption = 30;
	}


	void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player")) {
			Properties.GetInstance().active = (Properties.ActiveItem)this.ID;
			Properties.GetInstance().faithConsumption = this.faithConsumption;
			if (Properties.GetInstance().activeItem != null) {
				Vector3 pos = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
				GameObject temp = Instantiate(Properties.GetInstance().activeItem, other.transform.position + pos, Quaternion.identity) as GameObject;
				Properties.GetInstance().activeItem = null;
				temp.SetActive(true);
			}
			Properties.GetInstance().activeItem = this.gameObject;

			this.transform.SetParent(other.transform);
			this.gameObject.SetActive(false);

		}
	}
}
