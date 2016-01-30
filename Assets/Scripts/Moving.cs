using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	public Rigidbody2D body;
	public Vector2 velocity;

	void Awake(){
		body=GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		body.MovePosition(body.position+velocity*Time.fixedDeltaTime);
	}
}
