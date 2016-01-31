using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	// public Color color=Color.white;
	public ColorEnum color;
	public Color Color{
		get{
			return GameManager.Instance().GetColor(color);
		}
	}
	public SpriteRenderer[] srs;

	void Awake(){
		SetColor(Color);
	}
	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
