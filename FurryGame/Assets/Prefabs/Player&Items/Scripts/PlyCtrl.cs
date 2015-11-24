using UnityEngine;
using System.Collections;

public class PlyCtrl : MonoBehaviour {
	public float Speed = 12;
	public float Accel = 12;
	public float Gravity = 15;
	public float JumpHeight = 8;
	public float PushBackDistance = 50;
	public GameObject Bullet;

	[HideInInspector]public Vector3 moveDirection = Vector3.zero;
	[HideInInspector]public int Health = 100;
	[HideInInspector]public int[] Ammo;
	[HideInInspector]public int WeaponID = 1;
	[HideInInspector]public bool[] WeaponHas;

	private float GroundDistance;
	private float CurrentSpeed;
	private float StepSpeed;
	private bool CanShoot = true;
	private bool CanHurt = true;
	private bool CanFall = true;
	private int DamGet = 0;
	private bool IsItJumpingTho=false;
	private Animator anim;
	private AnimatorOverrideController AoC;
	private Rigidbody rigid;
	CharacterController controller;
	// Use this for initialization
	void Start () {	
		Ammo = new int[10];
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
		AoC = new AnimatorOverrideController();
		rigid = controller.attachedRigidbody;
		StartCoroutine ("HurtWait");
		WeaponHas [0] = false;
		WeaponHas [1] = true;
		Ammo [0] = 100; //Knife
		Ammo [1] = 100; //Shotgun

	}

	// Update is called once per frame
	void Update () {
		float jump = JumpHeight/3;
		if(IsItJumpingTho==true){
			//This somehow works.
			for (float i = jump; i < JumpHeight; i++) {
				jump += 5;
			}
			StartCoroutine ("JumpWait");
			//}
		}
		if (Health <= 0) {
			Destroy (gameObject);
		}
		if (Input.GetKey (KeyCode.RightArrow) && CanHurt==true) {
			anim.SetBool ("IsWalking",true);
			moveDirection.z = Speed / 4;
			transform.forward = new Vector3 (0, 0, 1) * 1;
		} else if (Input.GetKey (KeyCode.LeftArrow) && CanHurt==true) {
			anim.SetBool ("IsWalking",true);
			moveDirection.z = -Speed/4;
			transform.forward = new Vector3 (0, 0, 1) * -1;
		} else {
			moveDirection.z = 0;
			anim.SetBool ("IsWalking",false);
		}
		//Jumping
		if (controller.isGrounded) {
			if (Input.GetButtonDown ("Jump") || Input.GetKeyDown (KeyCode.Z)) {
				anim.SetTrigger ("Jumping");
				IsItJumpingTho = true;
				moveDirection.y = jump;
				CanFall = false;
				if(jump>5){
					IsItJumpingTho = false;
					CanFall = true;	
				}
			}
		}else{
			if(CanFall==true){
				moveDirection.y -= Gravity * Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Z) || Input.GetButtonUp ("Jump") && CanFall == false) {
			//anim.SetTrigger ("Jumping");
			StopCoroutine ("JumpWait");
			IsItJumpingTho = false;
			CanFall = true;
		}
		controller.Move (moveDirection * Time.deltaTime * Speed);
		//End Movement

		//Shooting	
		if(Input.GetKey(KeyCode.X) && CanShoot == true){
			if (Ammo[1] > 0) {
				anim.SetTrigger ("ShootingSG");
				Instantiate (Bullet, transform.position + transform.forward * 5, transform.rotation);
				CanShoot = false;
				Ammo[1]--;
				StartCoroutine (ShootWait ());
			}
		}
	}
	void OnCollisionEnter(Collision other){
		print ("I hit something, OH GOD THE FUCK DID I HIT? Hit :: "+other.gameObject.name);
		if(other.gameObject.tag == "Enemy"){
			if (CanHurt == true) {
				BasicEnemy Enemy = other.gameObject.GetComponent <BasicEnemy> ();
				Health -= Enemy.Damage;
				DamGet = Enemy.Damage;
				CanHurt = false;	
				PushBack (other);
				StartCoroutine (HurtWait ());
			}
		}
		if(other.gameObject.tag == "EnemyBullet"){
			if (CanHurt == true) {
				BulletCtrl Enemy = other.gameObject.GetComponent <BulletCtrl> ();
				Health -= Enemy.Damage;
				DamGet = Enemy.Damage;
				CanHurt = false;
				PushBack (other);
				StartCoroutine (HurtWait ());
				Destroy (other.gameObject);
			}
		}
	}
	void OnCollisionStay(Collision other){
		//print ("Colided with "+other.gameObject.name);
		if (other.gameObject.tag == "Enemy") {
			if (CanHurt == true) {
				BasicEnemy Enemy = other.gameObject.GetComponent <BasicEnemy> ();
				print ("Damaged?");
				Health -= Enemy.Damage;
				DamGet = Enemy.Damage;
				CanHurt = false;	
				StartCoroutine (HurtWait ());
				PushBack (other);
			}
		}
	}
	void OnGUI(){
		//if(GUI.Button(new Rect(10,10,150,100), "HP ::" + Health)){ Health += 10; }
		GUI.Box (new Rect (10, 10, 200, 20), Health + "/ 100");
		//GUI Guns Available
		GUI.Box (new Rect (10, 30, 25, 25), "1");
		GUI.Box (new Rect (35, 30, 25, 25), "2");
		GUI.Box (new Rect (60, 30, 25, 25), "3");
		GUI.Box (new Rect (85,30, 125, 25), "Ammo::"+Ammo);
		/*if(CanHurt==false){
			Vector3 ScreenPos = Camera.current.WorldToScreenPoint (transform.position);
			Rect rect = new Rect (ScreenPos.x - 50, ScreenPos.y - 350, 100, 24);
			GUI.Label (rect, "-"+(100-Health));
		}*/
	}

	public IEnumerator WaitForFall(){
		yield return new WaitForSeconds(.1f);
		CanFall = true;
	}
	public IEnumerator ShootWait(){
		yield return new WaitForSeconds (.2f);
		CanShoot = true;
	}
	public IEnumerator HurtWait(){
		//moveDirection.y = 5;
		yield return new WaitForSeconds (1);
		CanHurt = true;
	}
	public IEnumerator JumpWait(){
		yield return new WaitForSeconds (1);
		IsItJumpingTho = false;
		CanFall = true;
	}

	public void PushBack(Collision other){
		if(other.transform.position.z>=transform.position.z){
			//transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y+(PushBackDistance*10f), transform.position.z - (PushBackDistance*10f)), Speed/2);
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y, transform.position.z - (PushBackDistance*10f)), Speed/2);
		}
		if(other.transform.position.z<=transform.position.z){
			//transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y+(PushBackDistance*10f), transform.position.z + (PushBackDistance*10f)), Speed/2);
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y, transform.position.z + (PushBackDistance*10f)), Speed/2);
		}
		if(other.transform.position.y<transform.position.y){
			//transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, transform.position.y-(PushBackDistance*10f), transform.position.z), Speed/2);
			moveDirection.y = 5;
		}
		//moveDirection.y = 5;
	}

	void ChangeWeapon(int a2c){
		if(a2c<1){

		}
	}

	////////////END OF CLASS////////////
}