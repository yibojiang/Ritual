using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine;

public class Entity : MonoBehaviour {
	public List<ColorEnum> colors;
	public List<SpriteRenderer> sprites;
	public SkeletonRenderer[] srs;

	public bool AbsorbColor(ColorEnum _color){
		if (!colors.Contains(_color) ){
			colors.Add(_color);
			UpdateColor();	
			return true;
		}
		return false;
	}

	public void RemoveColor(ColorEnum _color){
		if (colors.Contains(_color) ){
			colors.Remove(_color);
		}
		// int removeID=-1;
		// for (int i=0;i<colors.Count;i++){
		// 	if (colors[i]==_color){
		// 		removeID=i;
		// 		break;
		// 	}
		// }

		// if (removeID!=-1){
		// 	colors.RemoveAt(removeID);
			UpdateColor();	
		// }
	}

	public bool ReleaseColor(out ColorEnum _color){
		// _color=Color.black;
		_color=ColorEnum.White;
		if (colors.Count>0){
			_color=colors[colors.Count-1];
			colors.RemoveAt(colors.Count-1);
			UpdateColor();	
			return true;
		}
		return false;
	}

	public Color GetColor(){
		// Color col=Color.black;
		// for(int i=0;i<colors.Count;i++){
		// 	col+=colors[i];
		// }
		// col.r=Mathf.Clamp01(col.r);
		// col.g=Mathf.Clamp01(col.g);
		// col.b=Mathf.Clamp01(col.b);
		// col.a=Mathf.Clamp01(col.a);

		// if (col==Color.black){
		// 	col=Color.white;
		// }
		// else if (col==Color.white){
		// 	col=Color.black;
		// }

		int finalCol=0;
		for(int i=0;i<colors.Count;i++){
			finalCol=finalCol | (int)colors[i];
		}
		// Debug.Log(finalCol);

		return GameManager.Instance().GetColor((ColorEnum)finalCol);
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
