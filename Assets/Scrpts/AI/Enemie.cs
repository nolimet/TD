using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {
	private GameObject currentWayPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWayPoint!=null){
		WayPoint w = currentWayPoint.GetComponent<WayPoint>();
			transform.rotation = w.direction;
			transform.localPosition+=new Vector3(1,0);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Waypoint"){
			if(currentWayPoint!=other.gameObject)
			{
				currentWayPoint = other.gameObject;
			}
		}
	}
}
