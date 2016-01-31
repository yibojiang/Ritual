using UnityEngine;
using System.Collections;

public class ColorPlatform : MonoBehaviour {
	public SpriteRenderer[] srs;

	public ColorEnum color;
	void Start(){
		GameManager gm=GameManager.Instance();
		SetColor(gm.GetColor(color));
	}

	public void SetColor (Color _color) {
		if (srs.Length==0){
			srs=GetComponentsInChildren<SpriteRenderer>();
		}
		// color=_color;
		for (int i=0;i<srs.Length;i++){
			if (srs[i].gameObject.name!="base"){
				srs[i].color=_color;	
			}
		}
		// Debug.Log("dropcol: "+_color);
	}

	
	public void SwtichColor(){
		int finalCol=(int)color;
		GameManager gm=GameManager.Instance();
		if (finalCol<gm.colors.Length-1){
			finalCol++;
		}
		else{
			finalCol=1;	
		}

		color=(ColorEnum)finalCol;
		SetColor(gm.GetColor(color));

		gm.player.UpdateColor();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
