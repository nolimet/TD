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
		//Debug.Log ("paused: "+paused);

		if(Input.GetKeyDown(KeyCode.Escape)){
			//openPauseMenu Later on
			//Application.LoadLevel(0);
			//Continue button does not work
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
				};
			}
		}
	}
}
