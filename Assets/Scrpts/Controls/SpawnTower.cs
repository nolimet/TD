using UnityEngine;
using System.Collections;

public class SpawnTower : MonoBehaviour {
	bool towerExists = false;

	void OnMouseDown () {
		if (!towerExists) {
			switch (GlobalStatics.selectedTower) {
			case 1:
				GameObject tower1 = Instantiate(Resources.Load<GameObject>("Towers/Tower1"), transform.position, Quaternion.identity) as GameObject;
				tower1.name = "Tower1";
				break;

			case 2:
				GameObject tower2 = Instantiate(Resources.Load<GameObject>("Towers/Tower2"), transform.position, Quaternion.identity) as GameObject;
				tower2.name = "Tower2";
				break;
			}

			towerExists = true;
		}
	}
}