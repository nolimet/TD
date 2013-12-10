using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	protected GameObject enemy;
	List<GameObject> enemiesInRange = new List<GameObject>();

	void OnTriggerEnter (Collider col) {
		if (col.tag == GlobalStatics.enemyTag) {
			enemiesInRange.Add(col.gameObject);
			enemy = enemiesInRange[0];
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == GlobalStatics.enemyTag) {
			if (enemiesInRange.Contains(col.gameObject)) {
				enemiesInRange.Remove(col.gameObject);
				if (col.gameObject == enemy) {
					if (enemiesInRange.Count >= 1) {
						enemy = enemiesInRange[0];
					} else {
						enemy = null;
						enemiesInRange.Remove(col.gameObject);
					}
				}
			}
		}
	}

	protected void Shoot () {
		Instantiate(Resources.Load<GameObject>("Bullets/Bullets1"), transform.position, Quaternion.identity);
	}
}