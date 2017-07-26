using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemySeeScript : MonoBehaviour {

	public enum STATE{
		MOVING,
		IDLE
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
	public float originalDirection;
	public float distanceThreshold = .1f;
	public bool chasingPlayer = false;

	//noise
	public Rigidbody echo;
	public float noiseTimeIdle = .7f;
	public float noiseTimeMoving = .3f;
	public bool inCoroutine = false;
	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag ("Player").transform;
		destination = transform.position;
		originalPosition = transform.position;
		originalDirection = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(transform.position.x -destination.x) < .1f && Mathf.Abs(transform.position.z - destination.z)< .1f) {
			state = STATE.IDLE;
		}
		if (state == STATE.IDLE) {
			if (!inCoroutine) {
				inCoroutine = true;
				StartCoroutine ("Makenoise", noiseTimeIdle);
			}
			transform.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			transform.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0f, 0f, 0f);
			//transform.rotation = Quaternion.Euler (0f, originalDirection+(45f* Mathf.Sin (Time.time * speed*2)), 0f);
			transform.rotation = Quaternion.Euler (0f, originalDirection, 0f);

		}
		if(state ==STATE.MOVING){
			if (!inCoroutine) {
				inCoroutine = true;
				StartCoroutine ("Makenoise", noiseTimeMoving);
			}
			if (chasingPlayer) {
				destination = Target.position;
			}
			transform.LookAt (destination);
			//transform.rotation = Vector3.RotateTowards(transform.rotation, destination, speed);
			transform.position = Vector3.MoveTowards (transform.position, destination, speed);
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
		destination = transform.position;
		chasingPlayer = false;
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
}
