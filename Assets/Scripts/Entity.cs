using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine;

public class Entity : MonoBehaviour {
	public ColorEnum color;
	public List<SpriteRenderer> sprites;
	public SkeletonRenderer[] srs;

	public bool AbsorbColor(ColorEnum _color){
		// if (!colors.Contains(_color) ){
		// 	colors.Add(_color);
		// 	UpdateColor();	
		// 	return true;
		// }
		if ( ( (int)color & (int)_color )==0 ){
			int finalCol=(int)color+(int)_color;
			color=(ColorEnum)finalCol;
			UpdateColor();	
			return true;
		}
		return false;
	}

	public void RemoveColor(ColorEnum _color){
		// if (colors.Contains(_color) ){
		// 	colors.Remove(_color);
		// }
		if ( ((int)color & (int)_color )!=0){
			int finalCol=(int)color-(int)_color;
			color=(ColorEnum)finalCol;
		}
		UpdateColor();	
		
	}

	public bool ReleaseColor(out ColorEnum _color){
		// _color=Color.black;
		// _color=ColorEnum.White;
		// if (colors.Count>0){
		// 	_color=colors[colors.Count-1];
		// 	colors.RemoveAt(colors.Count-1);
		// 	UpdateColor();	
		// 	return true;
		// }
		_color=color;
		if (color!=ColorEnum.White){
			color=ColorEnum.White;
			UpdateColor();	
			return true;
		}
		
		return false;
	}

	public bool GetReleaseColor(out ColorEnum _color){
		// _color=ColorEnum.White;
		// if (colors.Count>0){
		// 	_color=colors[colors.Count-1];
		// 	// colors.RemoveAt(colors.Count-1);
		// 	// UpdateColor();	
		// 	return true;
		// }
		_color=color;
		if (color!=ColorEnum.White){
			UpdateColor();	
			return true;
		}
		
		return false;
	}

	public Color GetColor(){
		

		// int finalCol=0;
		// for(int i=0;i<colors.Count;i++){
		// 	finalCol=finalCol | (int)colors[i];
		// }

		// return GameManager.Instance().GetColor((ColorEnum)finalCol);
		return GameManager.Instance().GetColor(color);
	}

	public void UpdateColor(){
		Color col=GetColor();

		for(int i=0;i<sprites.Count;i++){
			sprites[i].color=col;
		}

		if (srs==null){
			srs=GetComponents<SkeletonRenderer>();
		}

		if (srs!=null){
			for(int i=0;i<srs.Length;i++){
				srs[i].skeleton.R=col.r;
				srs[i].skeleton.G=col.g;
				srs[i].skeleton.B=col.b;
			}	
		}
		
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
