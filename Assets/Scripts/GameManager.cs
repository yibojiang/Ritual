using UnityEngine;
using System.Collections;

public enum ColorEnum{
	White=0,
	Red=1,
	Green=2,
	RG=3,
	Blue=4,
	RB=5,
	GB=6,
	RGB=7
}

public class GameManager : MonoBehaviour {
	private static GameManager instance ;
	public static  GameManager Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<GameManager>();
		return instance;
	}

	public Color[] colors;
	public Mob player;
	public Color GetColor(ColorEnum _colorEnum){
		return colors[(int)_colorEnum];
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
