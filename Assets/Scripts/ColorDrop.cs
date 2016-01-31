using UnityEngine;
using System.Collections;

public class ColorDrop : MonoBehaviour {
	public bool alive=true;
	// public Color color=Color.white;
	public SpriteRenderer[] srs;

	public ColorEnum color;

	void Start(){
		GameManager gm=GameManager.Instance();
		SetColor(gm.GetColor(color));
	}

	public void SetColor (Color _color) {
		// color=_color;
		for (int i=0;i<srs.Length;i++){
			if (srs[i].gameObject.name!="base"){
				srs[i].color=_color;	
			}
		}
		// Debug.Log("dropcol: "+_color);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other);
		if (alive){
			if (other.gameObject.CompareTag("Splash") ){
				// Debug.Log(other);
	 			GameManager gm=GameManager.Instance();
	 			Splash splash=other.gameObject.GetComponent<Splash>();
	 			splash.color=splash.color | color;
	 			splash.SetColor(gm.GetColor(splash.color));
	 			alive=false;
				GetComponent<Collider2D>().enabled=false;
	 		}	
		}
		
	}
	 void OnCollisionEnter2D(Collision2D coll) {
	 	if (alive){		
	 		if (coll.gameObject.CompareTag("Floor") ){
	        	foreach(ContactPoint2D missileHit in coll.contacts){
	        		GameObject splashPrefab=Resources.Load<GameObject>("Prefab/Splash1x1");
	        		
					Vector2 hitPoint = missileHit.point;
					GameObject splashObj=(GameObject)Instantiate(splashPrefab, hitPoint,Quaternion.identity);
					
					

					splashObj.transform.SetParent(coll.transform);
					GameManager gm=GameManager.Instance();

					Splash splash=splashObj.GetComponent<Splash>();
					splash.color=color;
					splash.SetColor(gm.GetColor(color));
					splash.transform.Find("water").transform.localScale=new Vector3(Random.Range(0.15f,0.25f), Random.Range(2f,10f) ,1);
					alive=false;
					GetComponent<Collider2D>().enabled=false;


					Destroy(this.gameObject);
					
					break;
				}
	        }	
	 	}
        
    }
}
