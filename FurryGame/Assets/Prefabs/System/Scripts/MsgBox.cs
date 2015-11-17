using UnityEngine;
using System.Collections;

public class MsgBox : MonoBehaviour {
	public bool Above=false;
	public string Text;
	public bool ShowText = false;
	public bool ExMark = false;
	public string ExMarkStr="!";
	void Update () {
		if (ShowText == true) {
			if (Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Z)) {
				//Destroy (gameObject);
				ShowText = false;
			}
		} else {
			if (Input.GetKey (KeyCode.DownArrow)) {
				ShowText = true;
			}
		}
	}
	void OnGUI(){
		Rect rect;
		if (Above == true){
			rect = new Rect (50, 64, Screen.width - 100, 100);
		}else{
			rect = new Rect (50, Screen.height - 125, Screen.width - 100, 100);
		}
		if (ShowText == true){
			if (GUI.Button (rect, Text)){
				ShowText = false;
			}
		}
		if(ExMark==true){
			GUI.Label (new Rect(Screen.width-25,Screen.height-25,25,25), ExMarkStr);
		}
	}
}
