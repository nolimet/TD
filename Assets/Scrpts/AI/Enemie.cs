using UnityEngine;
using System.Collections;
using Pathfinding;

public class Enemie : MonoBehaviour {

	public Transform target;
	private Vector3 targetPos;
	public float speed = 1;
	public float margenPath;
	 Seeker seeker;
	 Path path;

	 int currentWaypoint;
	public float nextWaypointDistance = 3;


	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		seeker.StartPath(transform.position,target.position,OnPathComplete);
		//Debug.Log("test");
	}

	public void OnPathComplete (Path p){
		Debug.Log ("mathComplete");
		if(!p.error){
			path = p;
			currentWaypoint=0;
		}else{
			Debug.LogError("NO VALID PATH CAN BEFOUND");
		}
	}

	void FixedUpdate () {
		if(targetPos!=target.position)
		{
			targetPos=target.position;
		}

		if(path == null){
			return;
		}

		if (currentWaypoint >= path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			return;
		}


		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized * speed;
		if(Vector3.Distance(transform.position,path.vectorPath[currentWaypoint])<margenPath){
		currentWaypoint++;
		}

		transform.LookAt(path.vectorPath[currentWaypoint]);
		transform.Translate(Vector3.forward*speed*Time.fixedDeltaTime);
	}


	void OnTriggerEnter(Collider other){

	}
}
