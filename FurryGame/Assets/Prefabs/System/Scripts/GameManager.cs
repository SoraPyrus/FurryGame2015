﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState{
	DEFAULT,		//Default, Running
	SCENE,			//Intro or Scene
	LOADING,		//Loading Scene
	STARTRUN,		//Start the Game the first time
	LOAD,			//Loading game, probably unused
	PAUSED,			//GamePaused
}

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.DEFAULT){
			DontDestroyOnLoad (GameObject.Find ("Player"));
		}
	}

}
