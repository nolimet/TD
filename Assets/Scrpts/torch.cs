using UnityEngine;
using System.Collections;

public class torch : MonoBehaviour {

	private Light Lamp;
	public float maxLamp;
	public float minLamp;
	public bool smooth=true;
	private bool paused = false;

	public Vector2 randomLightIntervalRange;
	private float randomLightTimer;
	void Start() {
		Lamp = GetComponent<Light>();
	}
	
	void Update () {
		if(!paused){
			if(smooth){
				float Lamppingpong = maxLamp-minLamp;
				Lamp.intensity=Mathf.PingPong(Time.time,Lamppingpong)+minLamp;
			}
			if(!smooth){
				if(randomLightTimer<=0){
				Lamp.intensity=Random.Range(minLamp,maxLamp);
				randomLightTimer=Random.Range(randomLightIntervalRange.x,randomLightIntervalRange.y);
				}
				randomLightTimer-=Time.deltaTime;
			}

		}
	}

	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}
}
