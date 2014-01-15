using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour {

	//activator
	public GameObject Trigger;

	//doors need atleast 2
	public GameObject[] Doors;

	//default setting of doors;
	public bool Dooropen = false;
	//renderers
	public Sprite spActive;
	private Sprite SpInactive;
	private SpriteRenderer spriteRenderer;
	
	void Start(){
		if(Doors.Length<1){
			Debug.LogError("need atleast 1 door");
		}
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		SpInactive=spriteRenderer.sprite;
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=spActive;

			//loop goes through the doors and opens it;
			foreach (GameObject Controling in Doors){
				Door conChange = Controling.GetComponent<Door>();
				conChange.opened=Dooropen;
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=SpInactive;

			//loop goes through each door and closes it;
			foreach (GameObject Controling in Doors){
				Door conChange = Controling.GetComponent<Door>();
				conChange.opened=!Dooropen;
			}
		}
	}
}
