using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour {

	public Transform player = null;
	public bool dualshock = false;
	public bool xboxGamePad = false;
	public bool pickedUp = false;
	public string pickUpText = null;
	public WaitForSeconds waitTime = new WaitForSeconds(0.3f);
	public bool isDevilItem = false;
	public ItemList.RelicRank rank = ItemList.RelicRank.none;
	public int price = 0;


	public void Update() {
		if (!pickedUp && Vector2.Distance(this.transform.position, player.position) <= 0.3f && 
		   ((dualshock && Input.GetKeyDown("joystick button 1")) || 
		   	(xboxGamePad && Input.GetKeyDown("joystick button 0")) || 
		   	Input.GetKeyDown(KeyCode.E))) {
			PickUp();
		}
	}


	public void Start() {
		dualshock = player.gameObject.GetComponent<PlayerBehaviour>().dualshock;
		xboxGamePad = player.gameObject.GetComponent<PlayerBehaviour>().xboxGamePad;
		StartCoroutine("InputCheck");
	}

	//metoda wywoływana przy podniesieniu przedmiotu
	public virtual void PickUp() {
		if (transform.parent != null) {
			if (Properties.GetInstance().money >= this.price) {
				Properties.ModifyMoneyCount(-this.price);
				Destroy(transform.parent.gameObject);
			} else {
				/* obsługa braku pinionszkuf */
				Debug.Log("Not enough money");
				return;
			}
		}
		GameObject temp = Instantiate(this.gameObject, Vector2.zero, Quaternion.identity) as GameObject;
		NewInventory.instance.AddToInventory(temp);
		pickedUp = true;
		Destroy(this.gameObject);
	}

	//sprawdzanie czy jest podłączony pad
	public IEnumerator InputCheck() {
		while (true) {
			dualshock = player.gameObject.GetComponent<PlayerBehaviour>().dualshock;
			xboxGamePad = player.gameObject.GetComponent<PlayerBehaviour>().xboxGamePad;
			yield return waitTime;
		}
	}

	//metoda którą wywołujemy po wyekwipowaniu relikwii
	public virtual void OnEquip() {
	
	}

	//metoda którą wywołujemy po zdjęciu relikwii
	public virtual void OnUnequip() {

	}
}
