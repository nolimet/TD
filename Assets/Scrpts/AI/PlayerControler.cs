using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	private bool paused;
	public float speed;
	public int PlayerNumb;
	public float rotationSpeed = 3f;


	// Use this for initialization
	void Start () {
	
	}

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
				else{
					rigidbody2D.velocity=new Vector2();
				}
			}
		}
	}
}
