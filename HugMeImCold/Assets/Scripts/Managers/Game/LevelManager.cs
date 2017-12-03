using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Text.RegularExpressions;

public class LevelManager : MonoBehaviour {

	// Files should be stored in some format--maybe have a grid class with tiles, and each tile has a type?
	// Might be too much for this-- could just be scene management
	// But tile type allows random sprites.
	// Should load every tile from savable format.
	// Probably just a text file.

	public GameObject ground;
	public GameObject player;
	public GameObject tree;
	public GameObject resource;

	//Tile[][] map;
	GameObject[,] GOmap;

	public float tileSize = 1;

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space))
			ReadLevelFromText (0);
	}

	// WARNING: I copied this from something else is that bad?
	void ReadLevelFromText(int levelNum){

		// From 4ndro1d at http://answers.unity3d.com/questions/577889/create-level-based-on-xmltxt-file.html
		// for reading the files, modified for this project.

		string file = "Assets/Levels/" + levelNum.ToString();
		string text = File.ReadAllText (file);
		string[] lines = Regex.Split (text, "\n"); // TODO: This might not work with carriage return.
		int rows = lines.Length;

		string[][] levelBase = new string[rows][];
		for (int i = 0; i < lines.Length; i++)  {
			string[] stringsOfLine = Regex.Split(lines[i], " ");
			levelBase[i] = stringsOfLine;
		}

		Array.Reverse (levelBase); // The array was read top down, but the level is built bottom up.

		BuildLevelMap(levelBase[0].Length,levelBase.Length); // TODO: This might not be the right deal.

		Debug.Log ("Made tile map with sizeX: " + levelBase [0].Length + " and sizeY: " + levelBase.Length);

		for (int y = 0; y < levelBase.Length; y++) {
			for (int x = 0; x < levelBase[0].Length; x++) {
				int c = ((int) (levelBase [y] [x] [0]  - '0')); // Be careful. [][] is y,x not x,y.
				TileType t = (TileType)c;
//				Debug.Log (t);
				GameObject go = GetPrefab (t);
				PlaceGameObject (go, x, y);
			}
		}
		InstantiateGOs ();
	}

	void BuildLevelMap(int width, int height){
//		Debug.Log (new GameObject[height][width]);
		GOmap = new GameObject[height, width];
	}

	void PlaceGameObject(GameObject go, int x, int y) {
		if (go == player){
			Debug.Log ("found player");
			GOmap [y,x] = ground; // we'll put ground beneath the player for now.
			Debug.Log(GOmap[y,x].name + " was put there");
//			PlacePlayer(x,y);
		}
		GOmap [y,x] = go;
	}

	void InstantiateGOs(){
		for (int y = 0; y < GOmap.Length; y++) {
			for (int x = 0; x < GOmap.GetLength(1); x++) {
//				Debug.Log (GOmap [y, x].name);
				GameObject newGO = GameObject.Instantiate (GOmap [y, x]);
				newGO.transform.position = new Vector2 (x * tileSize, y * tileSize);
			}
		}
	}

	void ClearLevel(){
		GOmap = new GameObject[1,1];
	}

	void PlacePlayer(int x, int y){
		GameObject newPlayer = GameObject.Instantiate (player);
		newPlayer.transform.position = new Vector2 (x*tileSize, y*tileSize);
	}

	GameObject GetPrefab(TileType tType) {

		GameObject returnObj = ground;
		
		switch (tType) {

		case TileType.empty:
			returnObj = ground;
			Debug.Break ();
			Debug.LogError ("What are you doing why are you putting an empty tile anywhere?");
			break;
		case TileType.ground:
			returnObj = ground;
			break;
		case TileType.playerSpawn:
			returnObj =  player;
			break;
		case TileType.resource:
			returnObj =  resource;
			break;
		case TileType.tree:
			returnObj =  tree;
			break;
		}
		return returnObj;
	}

}

public class Tile {
	public int _x;
	public int _y;

	public TileType _tType;

	public Tile (int x, int y, TileType tType) {
		_x = x;
		_y = y;
		_tType = tType;
	}
}

public enum TileType {
	//These are also used in the txt files
	empty = 0,
	ground = 1,
	playerSpawn = 2,
	tree = 3,
	resource = 4,
}
