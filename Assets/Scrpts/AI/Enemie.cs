using UnityEngine;
using System.Collections;
using Pathfinding;

public class Enemie : MonoBehaviour {

	public Transform target;
	public float Speed;
	public float margenPath;
	Seeker seeker;
	Path path;
	CharacterController CharControler;
	int currentWaypoint;


	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		seeker.StartPath(transform.position,target.position,OnPathComplete);
		CharControler = GetComponent<CharacterController>();
	}

	public void OnPathComplete (Path p){
		if(!p.error){
			path = p;
			currentWaypoint=0;
		}else{
			Debug.LogError(p.error);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(path == null){
			return;
		}

		if(currentWaypoint>= path.vectorPath.Count);
		{
			return;
		}

		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized * Speed;
		CharControler.SimpleMove(dir);
		if(Vector3.Distance(transform.position,path.vectorPath[currentWaypoint])<margenPath){
		currentWaypoint++;
		}
	}

	void OnTriggerEnter(Collider other){

	}
}
