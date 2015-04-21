using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(TerrainRenderer))]
public class TerrainRendererEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();

		TerrainRenderer t = (TerrainRenderer)target;
		if(t.terrainMap != null) 
			EditorGUILayout.IntField("Map Size",t.terrainMap.Length);
		else
			EditorGUILayout.IntField("Map Size",0);


		if (GUILayout.Button("Load Sprites")){
			TerrainRenderer terrainRenderer = (TerrainRenderer)target;
			terrainRenderer.LoadSprites();
		}
		if (GUILayout.Button("Render")){
			TerrainRenderer terrainRenderer = (TerrainRenderer)target;
			terrainRenderer.ClearImmediate();
			terrainRenderer.Render();
		}
		if (GUILayout.Button("Clear")){
			TerrainRenderer terrainRenderer = (TerrainRenderer)target;
			terrainRenderer.ClearImmediate();
		}
		if (GUILayout.Button("Load")){
		}
	}

}
