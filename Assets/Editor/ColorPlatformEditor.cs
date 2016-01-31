using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(ColorPlatform) ),CanEditMultipleObjects]
public class ColorPlatformEditor : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnInspectorGUI () {
		serializedObject.Update();
		ColorPlatform myScript =(ColorPlatform) target;
		DrawDefaultInspector();
		if (GUILayout.Button("SetColor")){
			myScript.SetColor(GameManager.Instance().GetColor(myScript.color));
		}
	}
}
