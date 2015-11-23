using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Manager<GameManager>{
	public enum GameState {
		Title,		//Title Screen
		Scene,		//Intro or Any Scene
		Loading,	//Loading or OnHold
		Pause,		//Main Pause State
		Inventory,	//Pause -- Inventory
		Options,	//Pause -- Options
		Default		//Neutral State, Game Runs
	};
	public GameState State;
	public int[] Ammo;
	public bool[] WeaponHas;
	public int WeaponID; 
	public int AmmountOfWeapons = 10;
	public int Money = 1000;


	void Start(){
		State = GameState.Title;
		Ammo = new int[10];
		WeaponHas = new bool[10];
	}

	void Update(){
		if (Application.loadedLevelName == "OrgGameIdea") {
			print ("Ayy0");
		}
		if(State == GameState.Pause){
			Time.timeScale = 0f;
		}
	}
}