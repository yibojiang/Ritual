using UnityEngine;
using System.Collections;

public class ColorFloor : MonoBehaviour {
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
			
			Color tmpColor=_color;
			tmpColor.a=0.5f;
			srs[i].color=tmpColor;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
