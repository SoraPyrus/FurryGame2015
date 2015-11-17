using UnityEngine;
using System.Collections;

public class BasicNavMovement : MonoBehaviour {
	public Transform Player;
	//GameObject Player;
	NavMeshAgent Nav;
	// Use this for initialization
	void Start () {
		Nav = GetComponent<NavMeshAgent> ();
		//Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//Nav.SetDestination (Player.position);
		//Nav.SetDestination (new Vector3(0,Player.transform.position.y,Player.transform.position.z));
		Nav.SetDestination (Player.position);
	}
}