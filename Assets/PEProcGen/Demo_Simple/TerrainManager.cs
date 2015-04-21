using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {
	public Transform player;
	public Transform terrain;

	void Start () {
		//GenerateCave();
		//GenerateRoom();
	}

	void GenerateCave(){
		CaveGenerator caveGenerator = terrain.GetComponent<CaveGenerator>();
		caveGenerator.Generate();
		CaveGenerator.Point? point = caveGenerator.FindNearestSpace(caveGenerator.currentMap,new CaveGenerator.Point(0,0));//Find nearest clear point to bottom corner of map
		if(point.HasValue) player.position = new Vector3(point.Value.x,point.Value.y,player.position.z) + terrain.position;//Terrain transform may not be at zero so map coordinates will be offset by its position
	}

	void GenerateRoom(){
		RoomGenerator roomGenerator = terrain.GetComponent<RoomGenerator>();
		roomGenerator.Generate();
		Rect rectFirstRoom = roomGenerator.FirstRoom();
		player.position = new Vector3(rectFirstRoom.center.x,rectFirstRoom.center.y,player.position.z) + terrain.position;//Place player in the centre of the first room (offset by the terrain transform position)
	}

	void OnGUI(){
		if(GUILayout.Button("GenerateCave")){
			GenerateCave();
		}
		if(GUILayout.Button("GenerateRoom")){
			GenerateRoom();
		}
	}

}
