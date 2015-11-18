using UnityEngine;
using System.Collections;

public enum GameState{
public class GameManager : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad();
	}

	public enum GameState{
		DEFAULT,		//Default, Running
		LOADING,		//Loading Scene
		STARTRUN,		//Start the Game the first time
		LOAD,			//Loading game, probably unused
		PAUSED,			//GamePaused
	}
}
