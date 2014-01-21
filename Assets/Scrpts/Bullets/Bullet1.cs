using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
	//GameObjects
	private Transform enemy;

	//integers
	private int lifeTime = 4;
	public int damage = 1;

	//floats
	private float deathTimer;
	private float bulletSpeed = 5f;
	//private float xDiff;
	//private float yDiff;
	private float offsetRot=0f;
	//private float radians;
	//private float degrees;

	//other
	//private Vector2 targetPoss = new Vector2();
	private bool paused = false;

	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindWithTag(GlobalStatics.playerTag);
		name = "Bullet";
	}

	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}

	public void getTarget(Transform target){
		enemy = target;
	}


	void Update () {
		if(!paused){
			if(enemy!=null){
				float xDiff = enemy.position.x - transform.position.x; 
				float yDiff = enemy.position.y - transform.position.y;
				
				float radians = Mathf.Atan2(yDiff, xDiff);
				//Debug.Log(radians);
				float degrees = ((radians * 180) / Mathf.PI) + offsetRot;
				
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, degrees);

				Vector2 move = new Vector2();

				//move.x = Mathf.Cos(transform.rotation.z * Mathf.PI) * bulletSpeed;
				//move.y = Mathf.Sin(transform.rotation.z * Mathf.PI) * bulletSpeed;

				move.x = Mathf.Cos(degrees/180*Mathf.PI) * bulletSpeed;
				move.y = Mathf.Sin(degrees/180*Mathf.PI) * bulletSpeed;

				rigidbody2D.velocity = move;

				deathTimer += Time.deltaTime;

				if (deathTimer >= lifeTime) {
					Destroy(gameObject);
				}
			}
			else{
				DestroyImmediate(this);
			}
		}else
		{
			rigidbody2D.velocity=new Vector2();
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == GlobalStatics.playerTag) {
			PlayerControler playercontrol = col.gameObject.GetComponent<PlayerControler>();
			playercontrol.hit(damage);
			Destroy(gameObject);
		}else if(col.tag == GlobalStatics.diggingTag){
			Destroy(gameObject);
		}
	}
}
