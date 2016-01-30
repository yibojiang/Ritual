using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	public Color color=Color.white;
	public SpriteRenderer sr;
	// Use this for initialization
	public void SetColor (Color _color) {
		color=_color;
		sr.color=_color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
