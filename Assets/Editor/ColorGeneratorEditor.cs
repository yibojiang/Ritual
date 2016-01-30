using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(ColorGenerator) ),CanEditMultipleObjects]
public class ColorGeneratorEditor : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnInspectorGUI () {
		serializedObject.Update();
		ColorGenerator myScript =(ColorGenerator) target;
		DrawDefaultInspector();
		if (GUILayout.Button("SetColor")){
			myScript.SetColor(GameManager.Instance().GetColor(myScript.color));
		}
	}
}
