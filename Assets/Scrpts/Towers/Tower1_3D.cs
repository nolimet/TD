using UnityEngine;
using System.Collections;

public class Tower1_3D : Tower_3D{
	private float time = 0;
	private float fireRate = 1;

	private Vector3 tempPos;

	// Update is called once per frame
	void Update () {
		if (target) {
			Debug.Log ("test");
			float xDiff;
			float zDiff;

			float radians;
			float degrees;

			//transform.rotation = Quaternion.FromToRotation(Vector3.up - transform.position, target.transform.position - transform.position);
			xDiff = transform.position.x - target.position.x;
			zDiff = transform.position.z - target.position.z;
			
			radians = Mathf.Atan2(zDiff, xDiff);
			degrees = (radians * 180) / Mathf.PI;

			transform.eulerAngles = new Vector3(transform.eulerAngles.x, degrees, transform.eulerAngles.z);

			time += fireRate * Time.deltaTime;

			if (time >= 0.5) {
				Shoot();

				time = 0;
			}
		}
	}
}