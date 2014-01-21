using UnityEngine;
using System.Collections;

public class liveGetGamma : MonoBehaviour {

	private Light lamp;
	
	void Start(){
		lamp=GetComponent<Light>();
	}

	void Update(){
		lamp.intensity=GlobalStatics.Gamma;
	}
}
