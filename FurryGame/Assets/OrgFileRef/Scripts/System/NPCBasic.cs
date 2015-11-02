using UnityEngine;
using System.Collections;

public class NPCBasic : MonoBehaviour {
	public float TalkDistance = 10;
	public string Text;
	private GameObject Player;
	MsgBox Msg;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		Msg = gameObject.AddComponent<MsgBox>();
		Msg.Text = Text;
	}
	
	// Update is called once per frame
	void Update () {
		float Dist = Vector3.Distance (Player.transform.position, transform.position);
		if(Dist<TalkDistance){
			Msg.ExMarkStr="Talk";
			Msg.ExMark = true;
			if(Input.GetKey (KeyCode.DownArrow)){
				Msg.ShowText = true;
				print (Dist+"--"+TalkDistance);
			}
		}
		if(Dist>TalkDistance){
			Msg.ShowText = false;
		}
	
	}
}
