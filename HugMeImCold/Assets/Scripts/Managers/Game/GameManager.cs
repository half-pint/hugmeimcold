﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private LevelManager levelManager;
	private Stat stat;

	public static GameManager instance = null;

	public int currentLevel = 0;


	// Use this for initialization
	void Awake () {

		if (instance == null)        
            instance = this;
        else if (instance != this)        
            Destroy(gameObject);    
            
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
		levelManager = GetComponent<LevelManager>();
        InitGame();
	}

	void InitGame(){
		//loadLevel
		levelManager.ReadLevelFromText(currentLevel);
	}

	public void win(){

		levelManager.ClearLevel();

		currentLevel ++;

		levelManager.ReadLevelFromText(currentLevel);

	}

	public void lose(){
		Debug.Log("Sob :(");
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
