using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {
	public int Health=2;
	public int Damage=1;
//	private GameObject Player;
//	private PlyCtrl Scr;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if(transform.forward.z>0f){
			transform.forward = new Vector3 (0, 0, 1) * 1;
		}else{
			transform.forward = new Vector3 (0, 0, 1) *-1;
		}
		if(Health<=0){
			GameObject Player = GameObject.Find ("Player");
			PlyCtrl PlyCr = Player.gameObject.GetComponent<PlyCtrl> ();
			//PlyCr.Ammo += 5;
			Destroy (gameObject);
		}
	}
}