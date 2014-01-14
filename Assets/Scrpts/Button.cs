using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject Trigger;
	public GameObject Controling;

	private Vector2 orginalForce;

	private Sprite inactive;
	public Sprite active;
	private SpriteRenderer spriteRenderer;
	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		inactive=spriteRenderer.sprite;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=active;
			AddForce conChange = Controling.GetComponent<AddForce>();
			orginalForce=conChange.force;
			conChange.force=new Vector2();
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=inactive;
			AddForce conChange = Controling.GetComponent<AddForce>();
			conChange.force=orginalForce;
		}
	}
}
