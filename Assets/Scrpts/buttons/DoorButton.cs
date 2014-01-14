using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour {

	public GameObject Trigger;
	public GameObject[] Doors;
	
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
			
			foreach (GameObject Controling in Doors){
				Door conChange = Controling.GetComponent<Door>();
				conChange.opened=true;
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=SpInactive;
			
			foreach (GameObject Controling in Doors){
				Door conChange = Controling.GetComponent<Door>();
				conChange.opened=false;
			}
		}
	}
}
