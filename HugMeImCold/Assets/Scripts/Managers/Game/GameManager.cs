using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private LevelManager levelManager;
	private Stat stat;

	public static GameManager instance = null;

	public int currentLevel = 0;

	CameraController cam;


	// Use this for initialization
	void Awake () {
		if (instance == null)        
            instance = this;
        else if (instance != this)        
            Destroy(gameObject);    
	
		cam = GameObject.FindObjectOfType<CameraController> ();
        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
		levelManager = GetComponent<LevelManager>();
        InitGame();

	}

	void InitGame(){
		//loadLevel
		levelManager.ReadLevelFromText(currentLevel);
	}

	public void Win(){

		levelManager.ClearLevel();

		currentLevel ++;

//		levelManager.ClearLevel ();
		if(currentLevel >= 6)
		{
			currentLevel = 0;
			SceneManager.LoadScene("won");	
		}
		else
		{		
			levelManager.ReadLevelFromText(currentLevel);
		}

	}

	public void Lose(){
		Debug.Log("Sob :( you lost");
		levelManager.ClearLevel ();
		currentLevel = 0;
		//InitGame ();
		SceneManager.LoadScene("lost");
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
