using UnityEngine;
using System.Collections;

public class setSortingLayer : MonoBehaviour {
	public int SortingLayer;
	// Use this for initialization
	void Awake () {
		renderer.sortingLayerID=SortingLayer;
	}
}
