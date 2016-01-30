using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private static CameraController instance ;
	public static  CameraController Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<CameraController>();
		return instance;
	}

	public Camera gameCam;
	public Transform target;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 tmpPos=gameCam.transform.position;
		tmpPos.x=target.position.x;
		tmpPos.y=target.position.y;
		gameCam.transform.position=tmpPos;

	}
}
