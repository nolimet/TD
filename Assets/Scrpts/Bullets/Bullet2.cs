using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {
	private bool paused = false;

	private int lifeTime = 4;
	public int damage = 1;

	private float deathTimer;
	private float bulletSpeed = 5f;

	private Vector2 move = new Vector2();
	private float offSetRot = 90f;

	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindWithTag(GlobalStatics.playerTag);
		name = "Bullet";

		//float degrees = ((transform.rotation.z * 180) / Mathf.PI);
		//Debug.Log(transform.rotation.eulerAngles.z);
		//Vector2 move = new Vector2();
		
		move.x = Mathf.Cos((transform.rotation.eulerAngles.z+offSetRot)/180*Mathf.PI) * bulletSpeed;
		move.y = Mathf.Sin((transform.rotation.eulerAngles.z+offSetRot)/180*Mathf.PI) * bulletSpeed;
	}
	
	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}

	// Update is called once per frame
	void Update () {
		if (!paused) {
			rigidbody2D.velocity = move;
			
			deathTimer += Time.deltaTime;
			
			if (deathTimer >= lifeTime) {
				Destroy(gameObject);
			}
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
