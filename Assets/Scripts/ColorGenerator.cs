using UnityEngine;
using System.Collections;

public class ColorGenerator : MonoBehaviour {
	public Color color;
	void OnTriggerEnter2D(Collider2D _collider){

		if (_collider.CompareTag("Mob")){
			Mob mob=_collider.GetComponent<Mob>();
			
			mob.AbsorbColor(color);
				
			
		}
	}
}
