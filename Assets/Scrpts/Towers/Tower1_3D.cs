using UnityEngine;
using System.Collections;

public class Tower1_3D : Tower_3D{
	private float time = 0;
	private float fireRate = 1;

	private float xDiff;
	private float yDiff;
	
	private float radians;
	private float degrees;

	private Vector3 tempPos;

	// Update is called once per frame
	void Update () {
		if (enemy) {
			//transform.rotation = Quaternion.FromToRotation(Vector3.up - transform.position, enemy.transform.position - transform.position);
			xDiff = transform.position.x - enemy.transform.position.x;
			yDiff = transform.position.z - enemy.transform.position.z;
			
			radians = Mathf.Atan2(yDiff, xDiff);
			degrees = (radians * 180) / Mathf.PI;

			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.z, degrees);

			time += fireRate * Time.deltaTime;

			if (time >= 0.5) {
				Shoot();

				time = 0;
			}
		}
	}
}