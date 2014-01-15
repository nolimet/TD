using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	private bool paused;
	public float speed;
	public int PlayerNumb;
	public float rotationSpeed = 3f;
	public bool isSmall = true;
	private GameObject hitFan;
	private enum statusenu{
		Normal,
		Fan,
		Dig
	}
	private statusenu status = statusenu.Normal;

	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}
	
	void Update ()
	{
		if (!paused) {
			if(PlayerNumb==GlobalStatics.currentChar){
				float hori = Input.GetAxis("Horizontal");
				float vert = Input.GetAxis("Vertical");

				if(hori!=0 || vert!=0)
				{
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(vert, hori) * Mathf.Rad2Deg + 90));
					rigidbody2D.AddForce(new Vector2(hori*speed,vert*speed));
				}
				else if(status==statusenu.Normal){
					rigidbody2D.velocity=new Vector2();
				}
			}
			else if(status==statusenu.Normal){
				rigidbody2D.velocity=new Vector2();
			}
			if(status==statusenu.Fan){
				AddForce force = hitFan.GetComponent<AddForce>();
				rigidbody2D.AddForce(force.force);
			}
		}
		else{
			rigidbody2D.velocity=new Vector2();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("triggered");
		if(isSmall){
			switch(other.tag){
			case GlobalStatics.fanTag:
				hitFan = other.gameObject;
				status = statusenu.Fan;
				//Debug.Log ("fan");
				break;
			case GlobalStatics.dirtTag:
				//Debug.Log(transform.tag);
				transform.tag = GlobalStatics.diggingTag;
				break;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(isSmall){
			switch(other.tag){
			case GlobalStatics.fanTag:
				status=statusenu.Normal;
				break;
			case GlobalStatics.dirtTag:
				Debug.Log(transform.tag);
				transform.tag = GlobalStatics.playerTag;
				break;
			}
		}

	}
}
