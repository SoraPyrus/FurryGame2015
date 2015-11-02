using UnityEngine;
using System.Collections;

public class CameraForce : MonoBehaviour {
	//public GameObject Player;
	private GameObject ply; //= GameObject.Find("Player");
	//public Transform ply;// = Player.transform;
	private Vector3 RelPos;
	//public GameObject obj;
	// Use this for initialization
	void Start () {
		ply = GameObject.Find ("Player");
		RelPos = ply.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position.x = Player.transform.position.x;
	//	transform.position.y = Player.transform.position.y;
		transform.position = ply.transform.position - RelPos;
	}
}
