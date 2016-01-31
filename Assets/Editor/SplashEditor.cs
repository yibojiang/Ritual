using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(Splash) ),CanEditMultipleObjects]
public class SplashEditor : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnInspectorGUI () {
		serializedObject.Update();
		Splash myScript =(Splash) target;
		DrawDefaultInspector();
		if (GUILayout.Button("SetColor")){
			myScript.SetColor(GameManager.Instance().GetColor(myScript.color));
		}
	}
}
