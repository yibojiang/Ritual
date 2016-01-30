using UnityEngine;
using System.Collections;

public class ColorFilter : MonoBehaviour {
	public Color color;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D _collider){

		if (_collider.CompareTag("Mob")){
			Mob mob=_collider.GetComponent<Mob>();
			
			mob.RemoveColor(color);
				
			
		}
	}
}
