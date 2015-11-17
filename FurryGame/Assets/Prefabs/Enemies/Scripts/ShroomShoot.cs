	using UnityEngine;
	using System.Collections;

	public class ShroomShoot : MonoBehaviour {
		//private BasicEnemy Self;
		private BEneMovement Move;
		private bool canShoot=true;
		public GameObject Bullet;
		private GameObject Player;
		private Rigidbody rigid;
		// Use this for initialization
		void Start () {
			//Self = GetComponent<BasicEnemy> ();
			Move = GetComponent<BEneMovement> ();
			Player = GameObject.Find ("Player");
			rigid = gameObject.AddComponent<Rigidbody>();

		}
		
		// Update is called once per fram
		void Update () {
			rigid.mass = 1;
			//GameObject Player = GameObject.Find ("Player");
			float Distance = Vector3.Distance (transform.position, Player.transform.position);
			if(Distance<=Move.SeekDistance){
				print ("Lemme See if I can shoot you.."); 
			if(transform.position.z>Player.transform.position.z){
				transform.forward = new Vector3 (0, 0, 1) * -1;
			}
			if(transform.position.z<Player.transform.position.z){
				transform.forward = new Vector3 (0, 0, 1) * 1;
			}
				//transform.LookAt (Player.transform);
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y, Player.transform.position.z), 15 * Time.deltaTime);
				if (canShoot == true) {
					Vector3 Direction = transform.position - Player.transform.position;
					print ("FGT YOU GOING DOWN");
					//Instantiate (Bullet, new Vector3(0,transform.position.y+5,transform.position.z), transform.rotation);
					BulletCtrl BCtrl = Bullet.GetComponent<BulletCtrl> ();
					//BCtrl.EnemyBullet = true;
					//Instantiate (Bullet, transform.position+Direction+(Vector3.up*15)+(Vector3.forward*-15), transform.rotation);
					Instantiate (Bullet, transform.position + transform.forward*7 + transform.up * 5, transform.rotation);
					canShoot = false;
					StartCoroutine (DelayShot ());
				}
			}
		}
		IEnumerator DelayShot(){
			yield return new WaitForSeconds(1.5f);
			canShoot=true;
		}
	}
