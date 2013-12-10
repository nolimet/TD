using UnityEngine;
using System.Collections;

public class SelectCharacter : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			GlobalStatics.chars = GlobalStatics.Characters.enemyFast;
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GlobalStatics.chars = GlobalStatics.Characters.enemyStronk;
		}
	}
}