using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
		private Transform target;
		private GameObject Player;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

		public void Start(){
			Player = GameObject.Find ("Player");
			target = Player.transform;
		}

        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
