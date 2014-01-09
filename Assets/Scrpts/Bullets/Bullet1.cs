using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
	//GameObjects
	private Transform enemy;

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
		//enemy = GameObject.FindWithTag(GlobalStatics.playerTag);
		name = "Bullet";
	}
	public void getTarget(Transform target){
		enemy = target;
	}


	void FixedUpdate () {
		if(enemy!=null){
			xDiff = transform.position.x - enemy.position.x;
			yDiff = transform.position.y - enemy.position.y;
			
			radians = Mathf.Atan2(yDiff, xDiff);
			degrees = (radians * 180) / Mathf.PI;

			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, degrees);

			rigidbody2D.velocity = Vector3.zero;
			//rigidbody2D.AddRelativeForce(-bulletSpeed, 0);
			//rigidbody2D.angularVelocity=1f;


			transform.localScale = - transform.localScale;

			deathTimer += 10 * Time.deltaTime;

			if (deathTimer >= lifeTime) {
				Destroy(gameObject);
			}
		}
		else{
			DestroyImmediate(this);
		}

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == GlobalStatics.playerTag) {
			Destroy(gameObject);
		}
	}
}
