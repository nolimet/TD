using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower_3D : MonoBehaviour {
	protected Transform target;
	List<Transform> targetsInRange = new List<Transform>();

	void OnTriggerEnter (Collider col) {
		Debug.Log ("triggerEntered");
		if (col.gameObject.tag == GlobalStatics.playerTag) {
			Debug.Log("TargetFound");
			targetsInRange.Add(col.gameObject.transform);
			target = targetsInRange[0];
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == GlobalStatics.playerTag) {
			if (targetsInRange.Contains(col.gameObject.transform)) {
				targetsInRange.Remove(col.gameObject.transform);
				if (col.gameObject.transform == target) {
					if (targetsInRange.Count >= 1) {
						target = targetsInRange[0];
					} else {
						target = null;
						targetsInRange.Remove(col.gameObject.transform);
					}
				}
			}
		}
	}

	protected void Shoot () {
		Instantiate(Resources.Load<GameObject>("Bullets/Bullets1"), transform.position, Quaternion.identity);
	}
}