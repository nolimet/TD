using UnityEngine;
using System.Collections;

public class SpawnCharacter : MonoBehaviour {
	bool charExists = false;

	void OnMouseDown () {
		if (!charExists) {
			switch (GlobalStatics.chars) {
			case GlobalStatics.Characters.enemyFast:
				GameObject tower1 = Instantiate(Resources.Load<GameObject>("Towers/Tower1"), transform.position, Quaternion.identity) as GameObject;
				tower1.name = "Tower1";
				break;

			case GlobalStatics.Characters.enemyStronk:
				GameObject tower2 = Instantiate(Resources.Load<GameObject>("Towers/Tower2"), transform.position, Quaternion.identity) as GameObject;
				tower2.name = "Tower2";
				break;
			}

			charExists = true;
		}
	}
}