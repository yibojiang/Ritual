using UnityEngine;
using System.Collections;

public class ColorGenerator : MonoBehaviour {
	public ColorEnum color;
	public SpriteRenderer[] srs;

	void Awake(){
		
		SetColor(GameManager.Instance().GetColor(color));
	}

	public void SetColor(Color _color){
		if (srs.Length==0){
			srs=GetComponentsInChildren<SpriteRenderer>();
		}
		

		for (int i=0;i<srs.Length;i++){
			if (srs[i].gameObject.name!="base"){
				srs[i].color=_color;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D _collider){

		if (_collider.CompareTag("Mob")){
			Mob mob=_collider.GetComponent<Mob>();
			GameManager gm=GameManager.Instance();
			
			mob.AbsorbColor(gm.GetColor(color));
				
			
		}
	}
}
