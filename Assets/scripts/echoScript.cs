using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoScript : MonoBehaviour {
	public float brightnessLeft = 1f;
	public float brightnessdecay = 0.05f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Decay ());
		StartCoroutine (Die ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collided){
		if (collided.tag == "glowShape") {
			collided.gameObject.SendMessage ("Glow", brightnessLeft);
		}
	}
	IEnumerator Decay(){
		yield return new WaitForSeconds (.05f);
		//brightnessLeft *= 1.5f;

		while (brightnessLeft > 0) {
			yield return new WaitForSeconds (brightnessdecay);
			brightnessLeft -= .1f;
		
		}
		Destroy (gameObject);
	}

	IEnumerator Grow(){
		for (int x = 0; x < 2; x++) {
			yield return new WaitForSeconds (.15f);
		}
	}
	IEnumerator Die(){
		yield return new WaitForSeconds (10f);
		Destroy (gameObject);
	}
}
 