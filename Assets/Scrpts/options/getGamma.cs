using UnityEngine;
using System.Collections;

public class getGamma : MonoBehaviour {

	private Light light;
	
	void Start(){
		light=GetComponent<Light>();
		light.intensity=GlobalStatics.Gamma;
	}
}
