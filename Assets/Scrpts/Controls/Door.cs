using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private Vector2 origen;
	public Vector2 MoveAmount;

	public bool opened = false;
	private float accuracy = 0.001f;
	private float speed = 3;

	
	void Start(){
		origen=transform.position;
	}

	void Update () {
		Quaternion temprot = transform.rotation;
		transform.rotation=Quaternion.identity;
		Vector3 temp = new Vector3();
		if(opened){
			temp=origen+MoveAmount;
		}else
		{
			temp=origen;
		}

		temp.z = transform.position.z;
		
		if(Vector3.Distance(transform.position,temp)>=accuracy){
			Vector3 dir = temp - transform.position;
			dir.z=0;
			transform.Translate(dir*speed*Time.deltaTime);
		}
		transform.rotation=temprot;
	}
}
