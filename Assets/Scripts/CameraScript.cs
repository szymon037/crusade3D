using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform Camera = null;
    public Transform Player = null;
    public Vector3 P = Vector3.zero;		//pozycja celownika w świecie gry
    public Camera c = null;
    public Vector3 slide = Vector3.zero;
    public float consta = 0.0f;
    public Vector2 distance = Vector2.zero;
    private float mouseX = 0f;
    private float mouseY = 0f;

	void Start () {
		consta = 0.00015f;
		Camera.position = new Vector3(Player.position.x, 100f, Player.position.z - 100f);	//100f = Camera.position.y
	}
	
	void Update () {

		mouseX = Mathf.Clamp(Input.mousePosition.x, 0f, c.pixelWidth);
		mouseY = Mathf.Clamp(Input.mousePosition.y, 0f, c.pixelHeight);
		
		P = c.ScreenToWorldPoint(new Vector3(mouseX, mouseY, c.nearClipPlane));	//pozycja celownika w świecie gry

		slide = new Vector3(P.x - Player.position.x, (P.y + P.z) - Player.position.z, 0f);		

		distance = new Vector2((P.x - Player.position.x), ((P.y + P.z) - Player.position.z));	

//wersja z funkcją x^3 - większe "pole martwe", imo lepiej wygląda
		Camera.position = new Vector3(Player.position.x + slide.x*slide.x*slide.x*consta/c.aspect,
									 100f, 
									 Player.position.z - Camera.position.y + slide.y*slide.y*slide.y*consta);

		//wartość, którą dodaję do Player.position.x jest podzielona przez c.aspect, ponieważ c.aspect to stosunek szerokości kamery do jej wysokości. 
		//Dzięki temu wartość, o którą kamera przesuwa się w osi X jest proporcjonalna do wartości, o którą kamera przesuwa się w osi Y.

//wersja z funkcją x^2 - mniejsze "pole martwe", trzeba zwiększyć consta
		/*Camera.position = new Vector3(Player.position.x + slide.x*slide.x*Mathf.Sign(slide.x)*consta/c.aspect,
									 100f, 
									 Player.position.z - Camera.position.y + slide.y*slide.y*Mathf.Sign(slide.y)*consta);*/


		
		
	}
}
