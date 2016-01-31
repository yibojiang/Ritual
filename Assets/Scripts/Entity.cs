using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine;

public class Entity : MonoBehaviour {
	public ColorEnum color;
	public List<SpriteRenderer> sprites;
	public SkeletonRenderer[] srs;

	public bool AbsorbColor(ColorEnum _color){
		if ( ( (int)color & (int)_color )==0 ){
			int finalCol=(int)color+(int)_color;
			color=(ColorEnum)finalCol;
			UpdateColor();	
			return true;
		}
		return false;
	}

	public void RemoveColor(ColorEnum _color){
		if ( ((int)color & (int)_color )!=0){
			int finalCol=(int)color-(int)_color;
			color=(ColorEnum)finalCol;
		}
		UpdateColor();	
		
	}

	public bool ReleaseColor(out ColorEnum _color){
		_color=color;
		if (color!=ColorEnum.White){
			color=ColorEnum.White;
			UpdateColor();	
			return true;
		}
		
		return false;
	}

	public bool GetReleaseColor(out ColorEnum _color){
		_color=color;
		if (color!=ColorEnum.White){
			UpdateColor();	
			return true;
		}
		
		return false;
	}

	public Color GetColor(){
		return GameManager.Instance().GetColor(color);
	}

	public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }

	public void UpdateColor(){
		Color col=GetColor();

		for(int i=0;i<sprites.Count;i++){
			sprites[i].color=col;
		}

		 ColorPlatform[] platforms = FindObjectsOfType<ColorPlatform>();
		 for (int i=0;i<platforms.Length;i++){
		 	if (platforms[i].color==color){
		 		
		 		SetLayerRecursively(platforms[i].gameObject,LayerMask.NameToLayer("Default"));
		 	}
		 	else{
		 		SetLayerRecursively(platforms[i].gameObject,LayerMask.NameToLayer("Ghost"));
		 	}
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
