using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	private bool paused;
	public float speed;
	public int PlayerNumb;

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
					rigidbody2D.AddForce(new Vector2(hori*speed,vert*speed));
				}
			}
		}
	}
}
