using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform[] Targets;
	public KeyCode SwitchCamPos;
	public float MoveTime = 1f;
	public float speed = 1f;
	public float accurcy = 0.1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Targets.Length>0){
			if(Input.GetKeyDown(SwitchCamPos)){
				GlobalStatics.currentChar++;
					if(GlobalStatics.currentChar>=Targets.Length){
					GlobalStatics.currentChar=0;
				}
			}

			Vector3 temp = Targets[GlobalStatics.currentChar].position;
			temp.z = -10;

			if(Vector3.Distance(transform.position,temp)>=accurcy){
				Vector3 dir = Targets[GlobalStatics.currentChar].position - transform.position;
				dir.z=0;
				transform.Translate(dir*speed*Time.deltaTime);
			}
		}
	}
}
