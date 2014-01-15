using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	bool activate1 = false;
	bool activate2 = false;
	
	// Update is called once per frame
	void Update () {
		if (activate1 && activate2) {
			Application.LoadLevel(2);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		switch (col.name) {
		case "Player1":
			activate1 = true;
			break;
			
		case "Player2":
			activate2 = true;
			break;
			
		default:
			break;
		}
	}

	void OnTriggerExit2D (Collider2D col){
		switch (col.name) {
		case "Player1":
			activate1 = false;
			break;
			
		case "Player2":
			activate2 = false;
			break;
			
		default:
			break;
		}
	}
}
