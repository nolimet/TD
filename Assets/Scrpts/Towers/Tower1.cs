using UnityEngine;
using System.Collections;

public class Tower1 : Tower {

	private float time = 0;
	private float fireRate = 1;

	private float xDiff;
	private float yDiff;
	
	private float radians;
	private float degrees;

	private Vector3 tempPos;

	// Update is called once per frame
	void Update () {
		if (enemiesInRange.Count>0) {
			//transform.rotation = Quaternion.FromToRotation(Vector3.up - transform.position, enemy.transform.position - transform.position);
			xDiff = enemy.position.x - transform.position.x; 
			yDiff = enemy.position.y - transform.position.y;
			
			radians = Mathf.Atan2(yDiff, xDiff);
			degrees = (radians * 180) / Mathf.PI;

			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, degrees);

			time += fireRate * Time.deltaTime;

			if (time >= 0.5) {
				Shoot();

				time = 0;
			}
		}
	}
}