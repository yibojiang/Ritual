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

	public SpriteRenderer fade;
	public void ColorTo(Color _color){
		AudioManager am=AudioManager.Instance();
		am.PlaySound(am.colorChangeClip);
		StartCoroutine(DoColorTo(_color) );
	}

	IEnumerator DoColorTo(Color _color){
		float toggle=0;
		float interval=0.2f;
		fade.color=_color;
		while (toggle<interval){
			toggle+=Time.deltaTime;
			// fade.color=_color;
			Color tmpCol=fade.color;
			tmpCol.a=1f-toggle/interval;
			fade.color=tmpCol;
			fade.transform.localScale=Vector3.Lerp(Vector3.zero,new Vector3(20,20, 1),toggle/interval );
			yield return new WaitForEndOfFrame();
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 tmpPos=gameCam.transform.position;
		tmpPos.x=target.position.x;
		tmpPos.y=target.position.y;
		gameCam.transform.position=tmpPos;

	}
}
