using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ActiveItem {

	void Awake() {
		ID = 0;
		faithConsumption = 25f;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player") {
			Destroy(gameObject);
			Properties.GetInstance().active = (Properties.ActiveItem)ID;
			Properties.GetInstance().faithConsumption = this.faithConsumption;

		}
	}
}
