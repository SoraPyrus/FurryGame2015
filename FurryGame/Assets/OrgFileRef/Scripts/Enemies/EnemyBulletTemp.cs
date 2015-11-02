using UnityEngine;
using System.Collections;

public class EnemyBulletTemp : MonoBehaviour {
	//Pretty Obvious, this is a Fork of BulletCtrl.
	public int Damage = 3;
	public float Speed = 1;
	void Start () {
		Destroy (gameObject,3);
	}
	void Update () {
		transform.position += transform.forward * Speed;
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {
			PlyCtrl Ene = other.GetComponent<PlyCtrl> ();
			Ene.Health -= Damage;
			print ("Damage Dealt" + Ene.Health);
		}	
		print ("Hit "+other);
		//Destroy (gameObject);
	}
}
