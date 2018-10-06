using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject inventory 	  		 = null;
	public Transform list 			  		 = null;
	public static List<RectTransform> items  = new List<RectTransform>(); //nasz ekwipunek
	private static Inventory instance 		 = null; //obiekt ekwipunku (znowu singleton)
	public Slider slider 			  		 = null; //obiekt typu Slider
	void Start() {
		if (Inventory.instance == null) {
			DontDestroyOnLoad(inventory);
			Inventory.instance = this;
		}
		else {
			Destroy(inventory);
		}
		inventory.SetActive(false); // domyślnie ustawiamy na wyłączony
		for(int i = 0; i < list.childCount; ++i) {
			items.Add(list.GetChild(i).GetComponent<RectTransform>()); //dodajemy wszystkie itemy z danego obiektu (jego dzieci)
		}
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.I) && inventory.activeSelf == false) { //aktywujemy ekwipunek klawiszem I po sprawdzeniu czy już nie jest włączony
			inventory.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.I) && inventory.activeSelf == true) { // analogicznie wyłączamy ekwipunek
			inventory.SetActive(false);
		}

		if (inventory.activeSelf == true) { //jeśli jest aktywowany
			for(int i = 0; i < items.Count; ++i) {
				RectTransform temp = items[i];

				Vector2 tempVector = Vector2.zero;
				tempVector.y = i * -70f + slider.value * items.Count * 70f; // do wektora pozycji listy dodajemy wartość slidera razy ilość przedmiotów
				temp.anchoredPosition = tempVector; //ustalamy pozycję na canvasie

				float y = tempVector.y;
				y = Mathf.Clamp(Mathf.Abs(y) / 60f, 0, 1); //clampujemy pomiędzy 0 i 1 żeby nie wyjechało poza 1 ani poniżej 0
				temp.GetComponent<CanvasGroup>().alpha	= 1f - y; //alpha ma być z przedziału <0, 1>, dlatego Clamp
			}

		}
	}

	public static void addToInventory(RectTransform temp) {
		items.Add(temp); 
	} 
}
