using UnityEngine;
using System.Collections;
public class BulletCtrl : MonoBehaviour {
	public int Damage = 1;
	public float Speed = 1;
	public bool EnemyBullet = false;
	//private Colision Col;
	//public bool EnemyBullet=false;
	void Start () {
		Destroy (gameObject, 1);
		//print (transform.forward);
	}
	void Update () {
		transform.position += transform.forward * Speed;

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			if (EnemyBullet == false) {
				BasicEnemy Ene = other.GetComponent<BasicEnemy> ();
				Ene.Health -= Damage;
				print ("Damage Dealt" + Ene.Health);
				print ("Hit "+other);
				Destroy (gameObject);
			}
		}
		if(other.tag == "ThePlayer"){
			if(EnemyBullet==true){
				PlyCtrl Ply = other.GetComponent<PlyCtrl> ();
				Ply.Health -= Damage;
				print ("Damage Dealt" + Ply.Health);
				print ("Hit "+other);
				//ply.Pusback(GetComponent<Ore>)
			}
		}
	}
}
