using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject menuGUI;
	private bool paused;

	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}

	void Update () {
		if(paused){
			menuGUI.SetActive(true);
		}
		else{
			menuGUI.SetActive(false);
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			if(paused){
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
				}
			}
			else{
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
