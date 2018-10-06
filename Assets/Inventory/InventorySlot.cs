using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public GameObject item = null;
	public Button itemButton;
	public GameObject temp = null;
	public bool relicSlot = false;
	//public GameObject inventory;

	void Start() {
		icon.enabled = false;
		itemButton = gameObject.GetComponentInChildren<Button>();
		//itemButton.interactable = false;
	}

	// ~InventorySlot() {
	// 	Clear();
	// }

	public void Add(GameObject item) {
		this.item = item;
		icon.sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
		icon.enabled = true;
		//itemButton.interactable = true;
	}

	public void Clear() {
		this.item = null;
		icon.sprite = null;
		icon.enabled = false;
		//itemButton.interactable = false;
	}

	public bool IsEmpty() {
		if (this.item != null) return false;
		return true;
	}

	// public void PickFromSlot() {
	// 	temp = Instantiate(this.item, Input.mousePosition, Quaternion.identity) as GameObject;
	// 	isBeingPickedUp = true;
	// }
}
