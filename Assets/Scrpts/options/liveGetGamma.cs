using UnityEngine;
using System.Collections;

public class liveGetGamma : MonoBehaviour {

	private Light light;
	
	void Start(){
		light=GetComponent<Light>();
	}

	void Update(){
		light.intensity=GlobalStatics.Gamma;
	}
}
