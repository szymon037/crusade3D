using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public 	GameObject 		GOcrosshair 	= null;
    private RectTransform 	rtCrosshair 	= null;
   	// public Camera 			cam 			= null;
    // private Vector3 			p 				= new Vector3(0f, 0f, 0f);		//wektor przechowujący pozycję celownika na płaszczyźnie kamery (w świecie gry)
   	// public 	Vector3 		attackDirection	= new Vector3(0f, 0f, 0f);		//wektor przechowujący pozycję, na którą wskazuje celownik w świecie gry


	void Start () {
		rtCrosshair = GOcrosshair.GetComponent<RectTransform>();
		Cursor.visible = false;

		//cam = Camera.main;
	}
	
	void Update () {
		//obsługa celownika w UI
		rtCrosshair.anchoredPosition = Input.mousePosition;

		//liczenie pozycji celownika na płaszczyźnie kamery (aktualnie w playerBehaviour)
		//p = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
		//pozycja na którą wskazuje celownik w świecie gry
		/*if(Input.GetMouseButtonDown(0))
			attackDirection = new Vector3(p.x, 0f, p.y+p.z);*/
	}
}
