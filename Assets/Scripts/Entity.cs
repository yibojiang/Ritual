using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour {
	public List<Color> colors;
	public List<SpriteRenderer> sprites;

	public bool AbsorbColor(Color _color){
		if (!colors.Contains(_color) ){
			colors.Add(_color);
			UpdateColor();	
			return true;
		}
		return false;
	}

	public bool ReleaseColor(){
		if (colors.Count>0){
			colors.RemoveAt(colors.Count-1);
			UpdateColor();	
			return true;
		}
		return false;
	}

	public void UpdateColor(){
		Color col=Color.black;
		for(int i=0;i<colors.Count;i++){
			col+=colors[i];
		}

		for(int i=0;i<sprites.Count;i++){
			sprites[i].color=col;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
