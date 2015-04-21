using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CaveGenerator))]
public class CaveGeneratorEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		CaveGenerator c = (CaveGenerator)target;

		if (GUILayout.Button("Generate")){
			c.Generate();
		}
	}

}
