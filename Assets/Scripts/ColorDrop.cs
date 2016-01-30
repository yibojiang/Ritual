using UnityEngine;
using System.Collections;

public class ColorDrop : MonoBehaviour {
	public bool alive=true;
	public Color color=Color.white;
	public SpriteRenderer sr;

	public void SetColor (Color _color) {
		color=_color;
		sr.color=_color;
	}

	 void OnCollisionEnter2D(Collision2D coll) {
	 	if (alive){
	 		if (coll.gameObject.CompareTag("Floor") ){
	        	foreach(ContactPoint2D missileHit in coll.contacts){
	        		GameObject splashPrefab=Resources.Load<GameObject>("Prefab/Splash");
	        		
					Vector2 hitPoint = missileHit.point;
					GameObject splashObj=(GameObject)Instantiate(splashPrefab, hitPoint,Quaternion.identity);
					splashObj.transform.SetParent(coll.transform);
					splashObj.GetComponent<Splash>().SetColor(color);
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
