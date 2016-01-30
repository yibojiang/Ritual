using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	public Color color=Color.white;
	public SpriteRenderer[] srs;

	void Awake(){
		SetColor(color);
	}
	// Use this for initialization
	public void SetColor(Color _color){
		if (srs.Length==0){
			srs=GetComponentsInChildren<SpriteRenderer>();
		}
		
		color=_color;
		for (int i=0;i<srs.Length;i++){
			srs[i].color=_color;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
