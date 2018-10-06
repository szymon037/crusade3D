using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewInventory : MonoBehaviour {


	
	public static NewInventory instance;

	public InventorySlot[] slots;
	public InventorySlot[] relicSlots;

	public Transform currentSlot = null;
	public Transform itemParent;

	public GameObject inventory = null;
	public GameObject currentItem = null;
	public GameObject[] invSlots;

	public Image currentImage = null;
	public Image tempImage = null;

	public Button[] buttons = null;
	public Button selected = null;
	public Button[,] buttons2d = null;
	public Button[] relicSlotButtons = null;

	public List<List<Button>> slotButtons = new List<List<Button>>();

	public GameObject player = null;
	public GameObject relicSlotParent = null;

	public bool choiceFlagHorizontal = false;
	public bool choiceFlagVertical = false;
	public bool isBeingPickedUp = false;
	
	public bool dualshock = false;
	public bool xboxGamePad = false;
	public bool usingRelicSlots = false;

	public int i = 2;
	public int j = 3;
	public int InventorySize = 28;
	public int rows = 0;
	public int columns = 0;

	public Color currentColor;

	private int index = 0;
	private int relicSize = 0;

	public RectTransform currentGameItemPicked = null;

	private WaitForSeconds waitTime = new WaitForSeconds(0.30f);

	~NewInventory() {
		Clear();
	}

	void Awake() {
		if (instance == null) instance = this;
	}

	void Start() {
		if (instance == null) instance = this;
		slots = itemParent.gameObject.GetComponentsInChildren<InventorySlot>();
		foreach (InventorySlot slot in slots) {
			slot.Clear();
		}
		relicSlots = relicSlotParent.gameObject.GetComponentsInChildren<InventorySlot>();
		foreach (InventorySlot slot in relicSlots) {
			slot.relicSlot = true;
		}
		relicSlotButtons = relicSlotParent.gameObject.GetComponentsInChildren<Button>();
		buttons = itemParent.gameObject.GetComponentsInChildren<Button>();
		player = GameObject.FindGameObjectWithTag("Player");
		buttons2d = new Button[i, j];
		Button[] tempArray = new Button[j];
		int tempIt = 0;
		int z = 0;
		for (int x = 0; x < i; ++x, tempIt = 0) {
			for (int y = 0; y < j; ++y) {
				buttons2d[x, y] = buttons[index];
				tempArray[tempIt++] = buttons[index++];
			}
			slotButtons.Add(tempArray.ToList());
		}
		slotButtons.Add(relicSlotButtons.ToList());
		index = 0;

		currentColor = buttons2d[0, 0].gameObject.GetComponent<Image>().color;
		StartCoroutine("InputCheck");
		inventory.SetActive(false);
		currentGameItemPicked.gameObject.SetActive(false);
	}

	void Update() {
		if (instance == null) instance = this;
		if ((Input.GetKeyDown("joystick button 7") && xboxGamePad) || (Input.GetKeyDown("joystick button 9") && dualshock) || Input.GetKeyDown(KeyCode.I) && !dualshock && !xboxGamePad) {
			inventory.SetActive(!inventory.activeSelf);
			currentGameItemPicked.gameObject.SetActive(!currentGameItemPicked.gameObject.activeSelf);
			currentGameItemPicked.gameObject.GetComponent<Image>().enabled = false;
			for (int i = 0; i < slots.Length; ++i) {
				if (slots[i].IsEmpty()) slots[i].Clear();
			}
		}

		if ((dualshock || xboxGamePad) && inventory.activeSelf) {
			
			try {
				slotButtons[rows][columns].gameObject.GetComponent<Image>().color = Color.blue;
				selected = slotButtons[rows][columns];
			} catch (System.ArgumentOutOfRangeException exception) {
				Debug.Log(rows.ToString() + " " + columns.ToString());
				rows = columns = 0;
			}
			
			float horizontalInput = Input.GetAxisRaw("Dpad Horizontal");
			if (horizontalInput != 0) {
				if (!choiceFlagHorizontal) return;
				choiceFlagHorizontal = false;
				if (horizontalInput > 0f) {
					slotButtons[rows][columns].gameObject.GetComponent<Image>().color = currentColor;
					try {
						if (columns >= slotButtons[rows].Count - 1) columns = 0;
						else ++columns;
					} catch (System.ArgumentOutOfRangeException e) {
						Debug.Log(e.ToString());
					}
					selected = slotButtons[rows][columns];
					selected.gameObject.GetComponent<Image>().color = Color.blue;
					horizontalInput = 0f;
					
				} else {
					slotButtons[rows][columns].gameObject.GetComponent<Image>().color = currentColor;
					if (columns <= 0) columns = slotButtons[rows].Count - 1;
					else --columns;
					selected = slotButtons[rows][columns];
					selected.gameObject.GetComponent<Image>().color = Color.blue;
					horizontalInput = 0f;
				}
			} else choiceFlagHorizontal = true;


			float verticalInput = Input.GetAxisRaw("Dpad Vertical");
			if (verticalInput != 0) {
				if (!choiceFlagVertical) return;
				choiceFlagVertical = false;
				if (verticalInput > 0f) {
					slotButtons[rows][columns].gameObject.GetComponent<Image>().color = currentColor;
					if (rows >= slotButtons.Count - 1) rows = 0;
					else ++rows;
					if (columns >= slotButtons[rows].Count) columns = slotButtons[rows].Count - 1;
					selected = slotButtons[rows][columns];
					selected.gameObject.GetComponent<Image>().color = Color.blue;
					verticalInput = 0f;
				} else {
					slotButtons[rows][columns].gameObject.GetComponent<Image>().color = currentColor;
					if (rows <= 0) rows = slotButtons.Count - 1;
					else --rows;
					selected = slotButtons[rows][columns];
					selected.gameObject.GetComponent<Image>().color = Color.blue;
					verticalInput = 0f;
				}
			} else choiceFlagVertical = true;
		}

		if (!dualshock && !xboxGamePad && inventory.activeSelf && selected != null) selected.gameObject.GetComponent<Image>().color = currentColor;
		if (inventory.gameObject.activeSelf && ((dualshock && Input.GetKeyDown("joystick button 1")) || (xboxGamePad && Input.GetKeyDown("joystick button 0")))) {
			if (selected != null) selected.onClick.Invoke();
		}
	}

	IEnumerator InputCheck() {
		while (true) {
			GamepadCheck();
			yield return waitTime;
		}
	}

	void GamepadCheck() {
		dualshock = player.gameObject.GetComponent<PlayerBehaviour>().dualshock;
		xboxGamePad = player.gameObject.GetComponent<PlayerBehaviour>().xboxGamePad;
	}

	bool IsFull() {
		foreach (InventorySlot slot in slots) {
			if (slot.item == null) return false;
		}
		return true;
	}

	bool IsEmpty() {
		foreach (InventorySlot slot in slots) {
			if (slot.item != null) return false;
		}
		return true;
	}

	public bool AddToInventory(GameObject item) {
		if (IsFull()) {
			Debug.Log("Inventory full! Make some space first.");
			return false;
		}
		for (int i = 0; i < slots.Length; ++i) {
			if (slots[i].item == null) {
				slots[i].Add(item);
				slots[i].item.SetActive(false);
				break;
			}
		}
		return true;
	}

	void Clear() {
		foreach (List<Button> tempList in slotButtons) {
			tempList.Clear();
		}
		slotButtons.Clear();
		System.Array.Clear(slots, 0, slots.Length);
		System.Array.Clear(relicSlots, 0, relicSlots.Length);
		System.Array.Clear(invSlots, 0, invSlots.Length);
		System.Array.Clear(buttons, 0, buttons.Length);
		System.Array.Clear(relicSlotButtons, 0, relicSlotButtons.Length);
		InventorySize 			= 0;
		instance 				= null;
		slots 					= null;
		inventory 				= null;
		isBeingPickedUp 		= false;
		dualshock 				= false;
		xboxGamePad 			= false;
		index 					= 0;
		i 						= 0;
		j 						= 0;
		rows 					= 0;
		columns 				= 0;
		currentColor 			= Color.clear;
		choiceFlagHorizontal 	= false;
		choiceFlagVertical 		= false;
	}

	
}
