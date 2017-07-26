using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDeactivatePuzzles : MonoBehaviour {
	public GameObject puzzleToActivate;
	public GameObject puzzleToDeactivate;

	void OnTriggerEnter(Collider collided){
		if (collided.tag == "Player") {
			//puzzleToActivate.SetActive (true);
			puzzleToDeactivate.SetActive (false);
		}
	}
}
