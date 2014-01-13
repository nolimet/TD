using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
	//GameObjects
	private Transform enemy;

	//integers
	private int lifeTime = 5;
	private float bulletSpeed = 5;

	//floats
	private float deathTimer;

	private float xDiff;
	private float yDiff;
	
	private float radians;
	private float degrees;

	private Vector2 targetPoss = new Vector3();
	private Vector2 move = new Vector2();

	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindWithTag(GlobalStatics.playerTag);
		name = "Bullet";
		if(enemy!=null){
			targetPoss = enemy.transform.position;
		}
	}
	public void getTarget(Transform target){
		enemy = target;
	}


	void Update () {
		if(enemy!=null){

			xDiff = targetPoss.x - transform.position.x; 
			yDiff = targetPoss.y - transform.position.y;
			
			radians = Mathf.Atan2(yDiff, xDiff);
			degrees = (radians * 180) / Mathf.PI;
			
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, degrees);
			
			move.x = Mathf.Cos(transform.rotation.z * Mathf.PI) * bulletSpeed;
			move.y = Mathf.Sin(transform.rotation.z * Mathf.PI) * bulletSpeed;

			rigidbody2D.velocity = move;
			//transform.localScale = - transform.localScale;

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
