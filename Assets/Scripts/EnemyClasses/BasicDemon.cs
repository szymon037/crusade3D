using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDemon : Enemy {

	private float attackTimer = 0f;
	public List<GameObject> pickups = new List<GameObject>();
	private bool isAttacking = false;
	private float temp = 0f;
	private Rigidbody body = null;
	//[SerializeField]
	void Start() {
		body = gameObject.GetComponent<Rigidbody>();
		knockback = 2f;
		speed = 0.75f;
		temp = speed;
	}

	void Update() {
		/* podążanie za graczem jeśli nie atakuje i nie jest trafiony */
		if (!isAttacking && !isHit) Chase();
		/* jeśli timer jest mniejszy lub równy zero i odległość od gracza jest mniejsza równa 0.3 to atakuje i ustawia timer pomiędzy atakami na 0.75*/
		if (Vector2.Distance(transform.position, player.position) <= 0.3f && attackTimer <= 0f) {
			Attack();
			attackTimer = 0.75f;
		}
		/* jeśli timer mniejszy równy zero to przeciwnik nie liczy się jako atakujący */
		if (attackTimer <= 0f) {
			isAttacking = false;
		}
		/* zmniejszanie licznika */
		if (attackTimer > 0f) {
			attackTimer -= Time.deltaTime;
		}
		/*jeśli trafimy przeciwnika to zostaje odrzucony i stopniowo wytraca prędkość */
		if (isHit) {
			body.velocity *= 0.75f;
		}
		if (hitTimer > 0f) {
			hitTimer -= Time.deltaTime;
		}
		if (hitTimer <= 0f) {
			isHit = false;
		}
		/*chyba tego nie muszę opisywać co */
		/* nie no musisz nie ma że mi się nie chce */
		if (health <= 0) Die();
	}

	void Attack() {
		isAttacking = true;
		LayerMask mask = -1;
		Vector3 temp = player.position - transform.position;
		RaycastHit2D hit = Physics2D.BoxCast(
			transform.position,
			Vector2.one * 0.1f,
			0f,
			temp,
			5f, 
			mask,
			0f,
			0.2f
		);
		Debug.DrawRay(transform.position, temp, Color.blue, 2f);

		if (hit.transform != null && hit.transform.gameObject.CompareTag("Player") && !Properties.GetInstance().flags["isHit"] && !Properties.GetInstance().flags["isRolling"]) {
			Properties.ModifyHealth(-(int)this.damage);
			Properties.ToggleFlag("isHit", true);
		}
	}

	void Chase() {
		transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.75f);
	}

	public override void Die() {
		Properties.ModifyFaith((int)faithRecovery);
		int temp = (int)(Random.value * 100);
		if (temp <= 20 && pickups.Count != 0) {
			int index = Random.Range(0, pickups.Count);
			Instantiate(pickups[index], this.transform.position, Quaternion.identity);

		}
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D other) {

	}
}
