using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(RoomGenerator))]
public class RoomGeneratorEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();

		RoomGenerator r = (RoomGenerator)target;
		if(GUILayout.Button("Generate")){
			r.Generate();
		}

	}

}
