using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyLightSwitch : MonoBehaviour {

	public enum STATE{
		MOVING,
		IDLE,
		RANDOM
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
	public float noiseTimeIdle = .7f;
	public float noiseTimeMoving = .3f;
	public float noiseTimeRandom = .5f;
	public bool inCoroutine = false;

	//blind
	public float blindSpeed = .05f;
	public float randomRotate = 45f;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = transform.GetComponent<Rigidbody> ();
		Target = GameObject.FindGameObjectWithTag ("Player").transform;
		destination = transform.position;
		originalPosition = transform.position;
		originalRotation = transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if (state == STATE.IDLE) {

		}
		if(state ==STATE.MOVING){
			if (!inCoroutine) {
				inCoroutine = true;
				StartCoroutine ("Makenoise", noiseTimeMoving);
			}
			if (chasingPlayer) {
				destination = Target.position;
				transform.LookAt (destination);

			}
			//transform.LookAt (destination);
			//transform.rotation = Vector3.RotateTowards
			//transform.rotation = Vector3.RotateTowards(transform.rotation, destination, speed);
			transform.position = Vector3.MoveTowards (transform.position, destination, speed);
		}
		if (state == STATE.RANDOM) {
			rb.velocity = transform.forward * blindSpeed;
			transform.rotation = Quaternion.Euler (0f, originalRotation.y*180 + (randomRotate* Mathf.Sin (Time.time * speed*2)), 0f);
			if (!inCoroutine) {
				inCoroutine = true;
				StartCoroutine ("Makenoise", noiseTimeRandom);
			}
		}



	}

	IEnumerator MoveTowardsAlarm(float timeToWait = 0f){
		yield return new WaitForSeconds(timeToWait);
		state = STATE.MOVING;
	}

	void ChasePlayer(){
		chasingPlayer = true;
		state = STATE.MOVING;
	}

	void Reset(){
		state = STATE.IDLE;
		transform.position = originalPosition;
		transform.rotation = originalRotation;
		//transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * 1f);
		destination = transform.position;
		chasingPlayer = false;
		transform.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
		transform.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0f, 0f, 0f);
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}
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

	void Blind(){
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
		randomRotate = UnityEngine.Random.Range (-90, 90);
		state = STATE.RANDOM;
		noiseTimeRandom = UnityEngine.Random.Range (1f, 9f);
		blindSpeed = UnityEngine.Random.Range (.2f, 1.3f);
		for (int x = 0; x < 10; x++) {
			StartCoroutine ("Makenoise", 0f);
		}
	}
}
