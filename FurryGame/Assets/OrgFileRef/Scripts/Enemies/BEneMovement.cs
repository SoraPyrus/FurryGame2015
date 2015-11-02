using UnityEngine;
using System.Collections;

public class BEneMovement : MonoBehaviour {
	public float SeekDistance = 50;
	public float Speed=15;
	private GameObject Player;
	public float Weight = 1;
	[HideInInspector]public Rigidbody Rigid;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		Rigid = GetComponent < Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		Rigidbody Ridig = GetComponent<Rigidbody> ();
		transform.LookAt (new Vector3 (0,0,Player.transform.position.z));
		float Distance = Vector3.Distance (transform.position, Player.transform.position);
		float step = Speed * Time.deltaTime;
		if (Distance <= SeekDistance) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(0,0,Player.transform.position.z), step);
			if(transform.position.z>Player.transform.position.z){
				transform.forward = new Vector3 (0, 0, 1) * -1;
			}
			if(transform.position.z<Player.transform.position.z){
				transform.forward = new Vector3 (0, 0, 1) * 1;
			}
		}
	}
}