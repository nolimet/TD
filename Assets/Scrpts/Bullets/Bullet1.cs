using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
	//GameObjects
	private GameObject enemy;

	//integers
	private int lifeTime = 5;
	private int bulletSpeed = 400;

	//floats
	private float deathTimer;

	private float xDiff;
	private float yDiff;
	
	private float radians;
	private float degrees;

	// Use this for initialization
	void Start () {
		enemy = GameObject.FindWithTag(GlobalStatics.enemyTag);
	}

	// Update is called once per frame
	void FixedUpdate () {
		xDiff = transform.position.x - enemy.transform.position.x;
		yDiff = transform.position.y - enemy.transform.position.y;
		
		radians = Mathf.Atan2(yDiff, xDiff);
		degrees = (radians * 180) / Mathf.PI;

		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, degrees);

		rigidbody.velocity = Vector3.zero;
		rigidbody.AddRelativeForce(-bulletSpeed, 0, 0);

		transform.localScale = - transform.localScale;

		deathTimer += 10 * Time.deltaTime;

		if (deathTimer >= lifeTime) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == GlobalStatics.enemyTag) {
			Destroy(gameObject);
		}
	}
}
