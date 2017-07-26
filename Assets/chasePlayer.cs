using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour {

	void OnTriggerEnter(Collider collided){
		if (collided.tag == "Player") {
			transform.parent.gameObject.SendMessage ("ChasePlayer");
		}
	}
}
