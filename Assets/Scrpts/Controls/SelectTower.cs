using UnityEngine;
using System.Collections;

public class SelectTower : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			GlobalStatics.selectedTower = 1;
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GlobalStatics.selectedTower = 2;
		}
	}
}