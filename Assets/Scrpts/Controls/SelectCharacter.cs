using UnityEngine;
using System.Collections;

public class SelectCharacter : MonoBehaviour {
	private bool paused=false;

	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}
	
	void Update () {
		if(!paused){
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				GlobalStatics.chars = GlobalStatics.Characters.enemyFast;
			} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
				GlobalStatics.chars = GlobalStatics.Characters.enemyStronk;
			}
		}
	}
}