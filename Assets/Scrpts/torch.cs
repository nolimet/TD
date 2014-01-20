using UnityEngine;
using System.Collections;

public class torch : MonoBehaviour {

	private Light light;
	public float maxlight;
	public float minlight;
	public bool smooth=true;
	private bool paused = false;

	public Vector2 randomLightIntervalRange;
	private float randomLightTimer;
	void Start() {
		light = GetComponent<Light>();
	}
	
	void Update () {
		if(!paused){
			if(smooth){
				float lightpingpong = maxlight-minlight;
				light.intensity=Mathf.PingPong(Time.time,lightpingpong)+minlight;
			}
			if(!smooth){
				if(randomLightTimer<=0){
				light.intensity=Random.Range(minlight,maxlight);
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
