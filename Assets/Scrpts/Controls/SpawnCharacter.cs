using UnityEngine;
using System.Collections;

public class SpawnCharacter : MonoBehaviour {
	bool charExists = false;

	void OnMouseDown () {
		if (!charExists) {
			switch (GlobalStatics.chars) {
			case GlobalStatics.Characters.enemyFast:
				GameObject enemy1 = Instantiate(Resources.Load<GameObject>("Enemies/Enemy1"), transform.position, Quaternion.identity) as GameObject;
				enemy1.name = "Enemy1";
				break;

			case GlobalStatics.Characters.enemyStronk:
				GameObject enemy2 = Instantiate(Resources.Load<GameObject>("Enemies/Enemy2"), transform.position, Quaternion.identity) as GameObject;
				enemy2.name = "Enemy2";
				break;
			}

			charExists = true;
		}
	}
}