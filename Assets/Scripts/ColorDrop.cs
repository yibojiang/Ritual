using UnityEngine;
using System.Collections;

public class ColorDrop : MonoBehaviour {
	public bool alive=true;
	// public Color color=Color.white;
	public SpriteRenderer[] srs;

	public ColorEnum color;

	void Awake(){
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
	}

	 void OnCollisionEnter2D(Collision2D coll) {
	 	if (alive){
	 		if (coll.gameObject.CompareTag("Floor") ){
	        	foreach(ContactPoint2D missileHit in coll.contacts){
	        		GameObject splashPrefab=Resources.Load<GameObject>("Prefab/Splash");
	        		
					Vector2 hitPoint = missileHit.point;
					GameObject splashObj=(GameObject)Instantiate(splashPrefab, hitPoint,Quaternion.identity);
					splashObj.transform.SetParent(coll.transform);
					GameManager gm=GameManager.Instance();
					
					splashObj.GetComponent<Splash>().SetColor(gm.GetColor(color));
					alive=false;
					GetComponent<Collider2D>().enabled=false;


					Destroy(this.gameObject);
					
					// Debug.Log(this.gameObject.name+" alive: "+alive);
					// Debug.Log(hitPoint);
					break;
				}
	        }	
	 	}
        
    }
}
