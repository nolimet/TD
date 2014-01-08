using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	protected Transform enemy;
	List<Transform> enemiesInRange = new List<Transform>();

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == GlobalStatics.playerTag) {
			enemiesInRange.Add(col.gameObject.transform);
			enemy = enemiesInRange[0];
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == GlobalStatics.playerTag) {
			if (enemiesInRange.Contains(col.gameObject.transform)) {
				enemiesInRange.Remove(col.gameObject.transform);
				if (col.gameObject == enemy) {
					if (enemiesInRange.Count >= 1) {
						enemy = enemiesInRange[0];
					} else {
						enemy = null;
						enemiesInRange.Remove(col.gameObject.transform);
					}
				}
			}
		}
	}

	protected void Shoot () {
		Instantiate(Resources.Load<GameObject>("Bullets/Bullets1"), transform.position, Quaternion.identity);
	}
}