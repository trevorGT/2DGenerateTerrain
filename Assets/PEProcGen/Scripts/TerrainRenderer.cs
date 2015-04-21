using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainRenderer : MonoBehaviour {
	public int [,] terrainMap;
	public string tilesetName;
	public GameObject prefabDefault;//If left blank the sprite_basic prefab in the Resources folder will be used
	public List<TileSet> tileSets;
	public bool reuse;

	void Start () {
		LoadSprites();
	}
	public void LoadSprites(){//Load the sprites from the resources folder
		foreach(var t in tileSets){
			Sprite[] sprites = Resources.LoadAll<Sprite>(t.Name);
			for (int i = 0; i < sprites.Length; i++) {
				if(i >= t.tileData.Count){
					TileData td = new TileData(){sprite = sprites[i]};
					t.tileData.Add(td);
				}else{
					t.tileData[i].sprite = sprites[i];
				}

			}
		}
	}
	public void Render(){
		if(terrainMap == null) return;
		if(tileSets == null || tileSets.Count == 0){Debug.Log("You must set up a tileset"); return;}
		TileSet currenTileSet = tileSets.Find(t => t.Name == tilesetName);//Find the currently specified tileset
		if(currenTileSet == null) currenTileSet = tileSets[0];//Couldnt find the tileset so just use the first one
		for (int y = 0; y < terrainMap.GetLength(1); y++) {
			for (int x = 0; x < terrainMap.GetLength(0); x++) {
				GameObject go = GetNextAvailable();
				go.transform.parent = this.transform;
				go.transform.localPosition = new Vector3(x,y,0);
				TileData tiledata = currenTileSet.tileData[terrainMap[x,y]];//Get all the info needed on this tile to render it
				SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
				spriteRenderer.sprite = tiledata.sprite;
				go.GetComponent<BoxCollider2D>().enabled = tiledata.boxCollider;
				go.name = "x: " + x + " y: " + y + " " + tiledata.sprite.name;
			}
		}
	}

	GameObject GetNextAvailable(){
		if(prefabDefault == null) prefabDefault = Resources.Load<GameObject>("sprite_basic");
		if(reuse){
			foreach(Transform child in this.transform){
				if(!child.gameObject.activeSelf){
					child.gameObject.SetActive(true);
					return child.gameObject;
				}
			}
		}
		return (GameObject)Instantiate(prefabDefault);
	}

	public void ClearImmediate(){
		if(reuse){
			foreach(Transform child in this.transform){
				child.gameObject.SetActive(false);
			}
			return;
		}
		int retrycount = 0;
		while(this.transform.childCount > 0 && retrycount <20){//Really tries to make sure all the child gameobjects are destroyed!
			foreach(Transform child in this.transform){
				DestroyImmediate(child.gameObject);
			}
			retrycount++;
		}
	}
}
