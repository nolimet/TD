using UnityEngine;
using System.Collections;

public class getGamma : MonoBehaviour {

	private Light lamp;
	
	void Start(){
		lamp=GetComponent<Light>();
		lamp.intensity=GlobalStatics.Gamma;
	}
}
