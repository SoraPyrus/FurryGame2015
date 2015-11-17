using UnityEngine;
using System.Collections;

public class BasicBomb : MonoBehaviour {
	public float Time = 10f;
	public float Radius = 50f;
	public int Damage=35;
	public bool Exploded=false;
	public bool Activate=false;
	private Collider[] Colliders;
	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForExplosion ());
	}
	// Update is called once per frame
	void Update () {
		if(Exploded==true){
			Colliders = Physics.OverlapSphere (transform.position, Radius);
			foreach(Collider hit in Colliders){
				if (hit.gameObject.tag == "Enemy") {
					hit.gameObject.GetComponent<BasicEnemy>().Health-=Damage;
				}
				if(hit.gameObject.tag == "Player"){
					hit.gameObject.GetComponent<PlyCtrl>().Health-=Damage/2;
				}
				if(hit.gameObject.tag=="Destroyable"){
					Destroy (hit.gameObject);
				}
				if(hit.GetComponent<Rigidbody>()){
						hit.GetComponent<Rigidbody> ().AddExplosionForce (Damage, transform.position, Radius);
				}
			}
			Destroy (gameObject);
		}
	}
	IEnumerator WaitForExplosion(){
		yield return new WaitForSeconds (Time);
		Exploded = true;
	}
}
