using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {
	
	void OnMouseDown(){
		//Debug.Log("test");
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseOver(){
		//Debug.Log("Test");
	}
}
