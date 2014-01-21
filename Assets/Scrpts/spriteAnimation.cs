using UnityEngine;
using System.Collections;

public class spriteAnimation : MonoBehaviour {

	public Sprite[] sprites;
	public float interval;
	private float time;
	private SpriteRenderer spRenderer;
	private int index;

	// Use this for initialization
	void Start () {
		spRenderer=GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;

		if(time>=interval)
		{
			//Debug.Log (index);
			index++;
			time=0;
		}
		if(index>=sprites.Length)
		{
			index=0;
		}
		spRenderer.sprite=sprites[index];
	}
}
