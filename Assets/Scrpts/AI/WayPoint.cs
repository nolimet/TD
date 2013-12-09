using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {
	public bool enableRender=true;
	public Quaternion direction;
	public GameObject NextWaypoint;
	// Use this for initialization
	void Start () {
		renderer.enabled=enableRender;
		//direction = transform.rotation.z+90f;
		Vector2 diff = new Vector2();
		diff.x = NextWaypoint.transform.position.x - transform.position.x;
		diff.y = NextWaypoint.transform.position.y - transform.position.y;
		
		direction = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
