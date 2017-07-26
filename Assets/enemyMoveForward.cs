using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveForward : MonoBehaviour {

	public enum STATE{
		IDLE,
		MARCH
	}
	public STATE state = STATE.IDLE;

	public void setState(STATE state){
		this.state = state;
	}

	//movement
	private Transform Target;
	public float speed = 2f;
	public Vector3 destination;
	public Vector3 originalPosition;
	public Quaternion originalRotation;
	public float distanceThreshold = .1f;
	public bool chasingPlayer = false;

	//noise
	public Rigidbody echo;
	public float noiseTimeMarch = 2f;
	public bool inCoroutine = false;

	//march
	public float marchSpeed = .05f;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = transform.GetComponent<Rigidbody> ();
		originalPosition = transform.position;
		originalRotation = transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if (state == STATE.MARCH) {
			rb.velocity = transform.forward * marchSpeed;
			if (!inCoroutine) {
				inCoroutine = true;
				StartCoroutine ("Makenoise", noiseTimeMarch);
			}
		}
	}

	void Reset(){
		state = STATE.IDLE;
		transform.position = originalPosition;
		transform.rotation = originalRotation;
		//transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * 1f);
		destination = transform.position;
		transform.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
		transform.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0f, 0f, 0f);
		
	}
	void OnTriggerEnter(Collider collided){
		if (collided.tag == "Player"){
			transform.parent.gameObject.SendMessage ("PlayerDied");
		}
	}
	IEnumerator Makenoise(float noiseTime){
		Instantiate (echo, transform.position, transform.rotation);
		yield return new WaitForSeconds(noiseTime);
		inCoroutine = false;
	}

	void StartMarching(){
		state = STATE.MARCH;
	}
	
	
}

