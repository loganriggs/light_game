using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amplifierScript : MonoBehaviour {
	public float amp = 2f;
	public float maxBrightness = 10f;

	void OnTriggerEnter(Collider collided){

		if (collided.tag == "echo") {
			if (collided.GetComponent<echoScript> ().brightnessLeft < maxBrightness) {
				collided.GetComponent<echoScript> ().brightnessLeft += amp;
			}
		}
	}
}
