using UnityEngine;
using System.Collections;

public class setGamma : MonoBehaviour {

	public Vector2 pos = new Vector2();

	void OnGUI() {
		GUI.TextField(new Rect(pos.x-10,pos.y-25,120,20),"SetGamma");
		GlobalStatics.Gamma = GUI.HorizontalSlider(new Rect(pos.x,pos.y,100,25),GlobalStatics.Gamma , 0.0F, 0.8F);
	}
}
