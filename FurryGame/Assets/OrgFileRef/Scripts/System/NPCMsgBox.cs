using UnityEngine;
using System.Collections;

public class NPCMsgBox : MonoBehaviour {
	public bool Above=false;
	public string Text;
	public float TalkDistance = 10;
	private GameObject Player;
	[HideInInspector]public bool ShowText = false;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	void Update () {
		Text.Replace ("___", "\n");
		float Dist = Vector3.Distance (Player.transform.position, transform.position);
		if (ShowText == true) {
			if (Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Z)) {
				//Destroy (gameObject);
				ShowText = false;
			}
		}else{
			if (Dist < TalkDistance) {
				if (Input.GetKey (KeyCode.DownArrow)) {
					ShowText = true;
				}
			}
		}
		if(Dist > TalkDistance){
			ShowText = false;
		}
	}
	void OnGUI(){
		Rect rect;
		if (Above == true) {
			rect = new Rect (50, 64, Screen.width - 100, 100);
		}else{
			rect = new Rect (50, Screen.height - 125, Screen.width - 100, 100);
		}
		if (ShowText == true) {
			//Debug.Log(Text.Replace("___", "\n"));
			if (GUI.Button (rect, Text.Replace("___","\n"))) {
				//Destroy (gameObject);
				ShowText = false;
			}
		}
	}
}
