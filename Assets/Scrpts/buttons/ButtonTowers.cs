using UnityEngine;
using System.Collections;

public class ButtonTowers: MonoBehaviour {

	public GameObject Trigger;
	public GameObject Controling;
	private Vector2 orginalForce;

	private Sprite SpInactive;
	public Sprite spActive;
	private SpriteRenderer spriteRenderer;
	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		SpInactive=spriteRenderer.sprite;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=spActive;
			TowerControler conChange = Controling.GetComponent<TowerControler>();
			conChange.Actived=false;
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=SpInactive;
			TowerControler conChange = Controling.GetComponent<TowerControler>();
			conChange.Actived=true;
		}
	}
}
