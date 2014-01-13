﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	protected Transform enemy;
	protected List<Transform> enemiesInRange = new List<Transform>();

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == GlobalStatics.playerTag) {
			enemy = col.gameObject.transform;
			enemiesInRange.Add(col.gameObject.transform);
			Debug.Log(enemiesInRange.Count);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == GlobalStatics.playerTag) {
			if (enemiesInRange.Contains(col.gameObject.transform)) {
				enemiesInRange.Remove(col.gameObject.transform);
				if (col.gameObject.transform == enemy) {
					if (enemiesInRange.Count >= 1) {
						enemy = enemiesInRange[0];
					} else {
						Debug.Log("testing");
						enemy = null;
						enemiesInRange.Remove(col.gameObject.transform);
					}
				}
			}
		}
	}

	/*void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Enemy") {
			if (targetsInRange.Contains(col.gameObject.transform)) {
				targetsInRange.Remove(col.gameObject.transform);
				if (col.gameObject.transform == target) {
					if (targetsInRange.Count >= 1) {
						target = targetsInRange[0];
					} else {
						target = null;
					}
				}
			}
		}
	}*/

	protected void Shoot () {
		GameObject bullet = Instantiate(Resources.Load<GameObject>("Bullets/Bullets1"), transform.position, Quaternion.identity) as GameObject;
		Bullet1 bulletScript = bullet.GetComponent<Bullet1>();
		bulletScript.getTarget(enemiesInRange[0]);
		bullet.transform.rotation=transform.rotation;
	}
}