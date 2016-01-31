﻿using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {
	public GameObject target;
	public GameObject btn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Mob")){
			btn.transform.localPosition=new Vector3(0, 0, 0);
			target.SendMessage("TriggerEvent");
		}
	}

	void OnTriggerExit2D(Collider2D other){
		// Debug.Log("OnTriggerExit2D");
		if(other.CompareTag("Mob")){
			btn.transform.localPosition=new Vector3(0, 0.11f, 0);
			
		}
	}
}
