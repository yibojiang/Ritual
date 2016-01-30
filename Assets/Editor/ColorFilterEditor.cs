using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(ColorFilter) ),CanEditMultipleObjects]
public class ColorFilterEditor : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnInspectorGUI () {
		serializedObject.Update();
		ColorFilter myScript =(ColorFilter) target;
		DrawDefaultInspector();
		if (GUILayout.Button("SetColor")){
			myScript.SetColor(GameManager.Instance().GetColor(myScript.color));
		}
	}
}
