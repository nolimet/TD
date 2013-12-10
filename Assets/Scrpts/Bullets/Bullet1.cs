using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
	GameObject enemy;
	float bulletSpeed = 200;

	// Use this for initialization
	void Start () {
		enemy = GameObject.FindWithTag(GlobalStatics.enemyTag);
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(enemy.transform.position);

		rigidbody.velocity = Vector3.zero;
		rigidbody.AddRelativeForce(0, 0, bulletSpeed);
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == GlobalStatics.enemyTag) {
			Destroy(gameObject);
		}
	}
}
