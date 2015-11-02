using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {
	public int AmmoToGive = 15;
	// Use this for initialization
	void Start () {
		Debug.Log ("Faggot Get Some Ammo already you trash.");
	}
	void OnCollisionStay(Collision other){
		//print ("Touch");
		if(other.gameObject.name == "Player"){
			PlyCtrl Player = other.gameObject.GetComponent<PlyCtrl>();
			Player.Ammo += AmmoToGive;
			Destroy (gameObject);
		}
	}
}
