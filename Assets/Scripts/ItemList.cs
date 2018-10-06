using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {

	public enum RelicRank {
		none = 0,
		first = 1,
		second = 2,
		third = 3
	}

	public static ItemList instance = null;
	
	public List<GameObject> unholyItems = new List<GameObject>();
	
	public List<GameObject> relics = new List<GameObject>();

	public List<GameObject> firstRankRelics = new List<GameObject>();

	public List<GameObject> secondRankRelics = new List<GameObject>();

	public List<GameObject> thirdRankRelics = new List<GameObject>();

	~ItemList() {
		Clear();
	}
	 
	//public List<GameObject> test = new List<GameObject>()
	void Awake() {
		if (ItemList.instance == null) {
			DontDestroyOnLoad(gameObject);
			ItemList.instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}

	public static void RemoveRelic(int index) {
		instance.relics.RemoveAt(index);
	}

	public static void RemoveRelic(GameObject obj) {
		instance.relics.Remove(obj);
	}

	public static void RemoveRelic(int index, RelicRank rank) {
		//instance.relics.RemoveAt(index);
		switch (rank) {
			case RelicRank.first:
				instance.firstRankRelics.RemoveAt(index);
				break;
			case RelicRank.second:
				instance.secondRankRelics.RemoveAt(index);
				break;
			case RelicRank.third:
				instance.thirdRankRelics.RemoveAt(index);
				break;
		}
	}

	public static void RemoveRelic(GameObject obj, RelicRank rank) {
		//instance.relics.Remove(obj);
		switch (rank) {
			case RelicRank.first:
				instance.firstRankRelics.Remove(obj);
				break;
			case RelicRank.second:
				instance.secondRankRelics.Remove(obj);
				break;
			case RelicRank.third:
				instance.thirdRankRelics.Remove(obj);
				break;
		}
	}

	public static void RemoveUnholy(int index) {
		instance.unholyItems.RemoveAt(index);
	}	
	
	public static void RemoveUnholy(GameObject obj) {
		instance.unholyItems.Remove(obj);
	}

	void Clear() {
		firstRankRelics.Clear();
		secondRankRelics.Clear();
		thirdRankRelics.Clear();
		unholyItems.Clear();
		firstRankRelics = null;
		secondRankRelics = null;
		thirdRankRelics = null;
		instance = null;
		unholyItems = null;
	}
}
