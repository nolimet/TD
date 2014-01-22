using UnityEngine;
using System.Collections;

public class setGamma : MonoBehaviour {

	[Range(0,100)]
	public float rangex;

	[Range(0,100)]
	public float rangey;
	private Vector2 pos = new Vector2();
	void Start() {
		Vector2 screenZ = new Vector2();
		screenZ.x = Screen.width;
		screenZ.y = Screen.height;

		pos.x=screenZ.x/100f*rangex;
		pos.y=screenZ.y/100f*rangey;
	}
	void OnGUI() {
		GUI.TextField(new Rect(pos.x-10,pos.y-25,120,20),"SetGamma");
		GlobalStatics.Gamma = GUI.HorizontalSlider(new Rect(pos.x,pos.y,100,25),GlobalStatics.Gamma , 0.0F, 0.8F);
	}
}
