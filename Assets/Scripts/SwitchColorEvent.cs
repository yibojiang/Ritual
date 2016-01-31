using UnityEngine;
using System.Collections;

public class SwitchColorEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TriggerEvent(){
		this.gameObject.SendMessage("SwtichColor");
	}
}
