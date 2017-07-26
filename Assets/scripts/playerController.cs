using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	//movement
	public Rigidbody rb;
	public float speed = 2f;

	public Vector3 resetPosition;

	//echo@
	public Rigidbody echo;
	public float echoSpeed = 4f;
	public bool canShoot = true;

	// Use this for initialization
	void Start () {
		resetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float moveUp = Input.GetAxis ("Vertical");
		float moveRight = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector3 (moveRight*speed, rb.velocity.y, moveUp*speed);
		Debug.Log (rb.velocity);
		//rotation
		if (moveUp > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else if (moveUp < 0) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		} else if (moveRight > 0) {
			transform.rotation = Quaternion.Euler (0, 90, 0);
		} else if (moveRight < 0) {
			transform.rotation = Quaternion.Euler (0, 270, 0);

		}
		if (Input.GetKeyDown (KeyCode.Space) && canShoot) {
			canShoot = false;
			StartCoroutine (DelayShoot());
			Vector3 shootPos = transform.position + new Vector3 (0, 0, 0);
			Rigidbody echoClone = Instantiate (echo, shootPos, transform.rotation) as Rigidbody;
			echoClone.velocity = (echoSpeed * echoClone.transform.forward);
		}
	}
	void Reset(){
		transform.position = resetPosition;
	}

	IEnumerator DelayShoot(){
		yield return new WaitForSeconds (0.2f);
		canShoot = true;
	}
}
