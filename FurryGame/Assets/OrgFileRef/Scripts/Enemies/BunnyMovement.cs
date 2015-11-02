	using UnityEngine;
	using System.Collections;

	public class BunnyMovement : MonoBehaviour {
		public float SeekDistance=50;
		public float Speed = 15;
		public float JumpDistance=10;
		public float JumpHeight = 15;

		private GameObject Player;
		private Rigidbody rigid;
		private bool Jumping=false;

		void Start(){
			Player = GameObject.Find ("Player");
			rigid = GetComponent<Rigidbody> ();
		}

		void Update(){
			float Distance = Vector3.Distance (transform.position, Player.transform.position);
			float Step = Speed * Time.deltaTime;
			if(Distance<SeekDistance){
				if(transform.position.z>Player.transform.position.z){
					transform.forward = new Vector3 (0, 0, 1) * -1;
				}
				if(transform.position.z<Player.transform.position.z){
					transform.forward = new Vector3 (0, 0, 1) * 1;
				}
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y, Player.transform.position.z), Step);
				if(Distance<SeekDistance){
					if(Jumping==false){
						StartCoroutine ("Jump");
					}
				//if()
				}else{
					Jumping = false;
				}
			}
		}
	//bool IsGrounded(){
//		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
	//}
		IEnumerator Jump(){
			yield return new WaitForSeconds (.5f);
			Jumping = true;
	//		rigid.AddForce (new Vector3 (0, JumpHeight * 2, transform.forward.z));
			rigid.AddForce (transform.up * (JumpHeight*1.5f));
			//print ("Jumped!!");
		}
	}