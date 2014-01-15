using UnityEngine;
using System.Collections;

public class ButtonTowers: MonoBehaviour {

	//player that activateds
	public GameObject Trigger;

	//controling objects
	public GameObject[] Towers;

	//renderers
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

			foreach (GameObject Controling in Towers){
				TowerControler conChange = Controling.GetComponent<TowerControler>();
				conChange.Actived=false;
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=SpInactive;

			foreach (GameObject Controling in Towers){
				TowerControler conChange = Controling.GetComponent<TowerControler>();
				conChange.Actived=true;
			}
		}
	}
}
