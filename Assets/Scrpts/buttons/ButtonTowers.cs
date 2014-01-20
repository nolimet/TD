using UnityEngine;
using System.Collections;

public class ButtonTowers: MonoBehaviour {

	//player that activateds
	public GameObject Trigger;

	//controling objects
	public GameObject[] Towers;

	//bools
	public bool Toggle = false;
	private bool paused=false;
	private bool towersActive = true;

	//renderers
	private Sprite SpInactive;
	public Sprite spActive;
	private SpriteRenderer spriteRenderer;

	//others
	public float timeActive = 0f;
	private float timer;

	void Start(){

		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		SpInactive=spriteRenderer.sprite;
	}

	void Update(){
		if(Toggle&&!paused){
			if(!towersActive){
				timer+=Time.deltaTime;
				Debug.Log(timer);
				if(timer>=timeActive)
				{
					timer=0;
					spriteRenderer.sprite=SpInactive;
					towersActive=true;
					foreach (GameObject Controling in Towers){
						TowerControler conChange = Controling.GetComponent<TowerControler>();
						conChange.Actived=true;
					}
				}
			}
		}
	}
	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
			spriteRenderer.sprite=spActive;
			towersActive = false;
			foreach (GameObject Controling in Towers){
				TowerControler conChange = Controling.GetComponent<TowerControler>();
				conChange.Actived=false;
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if(!Toggle){
			if(col.tag == GlobalStatics.playerTag && Trigger == col.gameObject){
				spriteRenderer.sprite=SpInactive;

				foreach (GameObject Controling in Towers){
					TowerControler conChange = Controling.GetComponent<TowerControler>();
					conChange.Actived=true;
				}
			}
		}else{
			timer=0;
		}
	}
	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}
}
