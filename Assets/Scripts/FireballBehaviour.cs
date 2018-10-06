using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour {

	public Vector3 direction;

	public float projS = 0.5f;
	
	public Transform player;

	void Start () {
		
	}

	void Update () {
		Vector3 pos = this.transform.position - direction;
		float angle = Mathf.Atan2(pos.z, pos.x) * Mathf.Rad2Deg;		//Mathf.Atan2(pos.y, pos.x)
		this.transform.position = Vector2.MoveTowards(transform.position, transform.position - direction, Time.deltaTime * projS);
		
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		Destroy(gameObject, 4);
	
	}
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player" && Properties.GetInstance().flags["isHit"] == false && Properties.GetInstance().flags["isRolling"] == false) {
			Properties.GetInstance().health -= 10;
			other.gameObject.GetComponent<PlayerBehaviour>().healthDisplay.text = "Health: " + Properties.GetInstance().health.ToString();
			Destroy(gameObject);
			Properties.GetInstance().flags["isHit"] = true;
		}
	}
}
