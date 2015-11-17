using UnityEngine;
using System.Collections;

public class Exp01 : MonoBehaviour {
	public float SeekDistance = 40;
	public float AttackDistance=20;
	public float Speed = 15;
	[HideInInspector]public Rigidbody rigid;

	private GameObject Player;
	private Animator anim;
	private AnimatorOverrideController AoC;
	private bool CanAttack=true;
	

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		//rigid = gameObject.AddComponent<Rigidbody>();
		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		AoC = new AnimatorOverrideController ();


	}
	
	// Update is called once per frame
	void Update () {
		float Distance = Vector3.Distance (transform.position, Player.transform.position);
		float step = Speed * Time.deltaTime;
		if(Distance<SeekDistance){
			if(transform.position.z>Player.transform.position.z){
				transform.forward = new Vector3 (0, 0, 1) * -1;
			}
			if(transform.position.z<Player.transform.position.z){
				transform.forward = new Vector3 (0, 0, 1) * 1;
			}
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y, Player.transform.position.z), step);
			anim.SetBool ("IsMoving",true);
			if(Distance<AttackDistance){
				if(CanAttack==true){
					anim.SetTrigger ("Attack");
					//rigid.AddForce (Vector3.forward * 15);
					//AttackGoesHere
				}
			}
		}
	}

	IEnumerator DelayAttack(){
		yield return new WaitForSeconds (1.5f);
		CanAttack = true;
	}
}
