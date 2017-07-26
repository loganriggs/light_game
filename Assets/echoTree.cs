using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoTree : MonoBehaviour {
	public float brightnessLeft = 10f;
	public float growTime = .15f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Decay ());
		StartCoroutine (Grow ());
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
		yield return new WaitForSeconds (10f);
		Destroy (gameObject);
	}

	IEnumerator Grow(){
		for (int x = 0; x < 100; x++) {
			transform.localScale *= 1.1f;
			yield return new WaitForSeconds (growTime);
		}
	}
}
