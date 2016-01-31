using UnityEngine;
using System.Collections;

public class ColorFilter : MonoBehaviour {
	public ColorEnum color;
	public SpriteRenderer[] srs;
	public GameObject activePart;

	void Awake(){
		GameManager gm=GameManager.Instance();
		SetColor(gm.GetColor(color));
		UpdateStates();
	}
	// Use this for initialization
	public void SetColor(Color _color){
		if (srs.Length==0){
			srs=GetComponentsInChildren<SpriteRenderer>();
		}
		
		// color=_color;
		for (int i=0;i<srs.Length;i++){
			if (srs[i].gameObject.name!="base"){
				srs[i].color=_color;	
			}
			
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D _collider){

		if (_collider.CompareTag("Mob")){
			Mob mob=_collider.GetComponent<Mob>();
			GameManager gm=GameManager.Instance();
			mob.RemoveColor(color);
				
			
		}
	}

	public bool isOn=true;
	
	void UpdateStates(){
		if (isOn){
			activePart.SetActive(true);
			GetComponent<Collider2D>().enabled=true;
		}
		else{
			activePart.SetActive(false);
			GetComponent<Collider2D>().enabled=false;
		}
	}

	public void SwtichOnOff(){
		isOn=!isOn;
		UpdateStates();
	}
}
