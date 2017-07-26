using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint: MonoBehaviour {
	public GameObject deactivateThisPuzzle;
	public GameObject reactivateThisPuzzle;
	private Vector3 playerPosition;

	void OnTriggerEnter(Collider collided){
		if (collided.tag == "Player") {
			collided.GetComponent<playerController> ().resetPosition = collided.transform.position;
			Debug.Log ("CheckPoint");
			//deactivate puzzle two behind
			//activate puzzle two ahead
		}
	}

}
