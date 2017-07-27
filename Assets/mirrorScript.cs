using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorScript : MonoBehaviour {
	public int rotateBy = 45;
	public int rotateY;
	public float rotate1;

	public bool canRotate = false;

	public bool canStartPush = true;
	public bool canEndPush = true;
	void Start(){
		rotateY = (int)transform.localRotation.eulerAngles.y;

	}

	void OnTriggerEnter(Collider collided){
		if (collided.tag == "echo") {
			Vector3 vel = collided.attachedRigidbody.velocity;
			if (rotateY == 0) {
				if (Mathf.Abs(vel.z)>1) {
					collided.attachedRigidbody.velocity *= -1;
				}
			}
			else if (rotateY == 90) {
				if (Mathf.Abs(vel.x)>1) {
					collided.attachedRigidbody.velocity *= -1;
				}
			}
			else if (rotateY == 45) {
				collided.attachedRigidbody.velocity = new Vector3 (-vel.z, vel.y, -vel.x);
				collided.transform.Rotate (0, 90, 0);
				collided.transform.position = new Vector3 (transform.position.x, collided.transform.position.y, transform.position.z);
			}
			else if (rotateY == 135) {
				collided.attachedRigidbody.velocity = new Vector3 (vel.z, vel.y, vel.x);
				collided.transform.Rotate (0, 90, 0);
				collided.transform.position = new Vector3 (transform.position.x, collided.transform.position.y, transform.position.z);
			}
		}
	}

	void OnCollisionStay(Collision collided){
		if (canRotate) {
			if (collided.transform.tag == "Player") {
				if (canStartPush) {
					canStartPush = false;
					StartCoroutine (RotateMirror (collided));
				}
			}
		}
	}

	void OnCollisionExit(Collision collided){
		if (canRotate) {
			if (collided.transform.tag == "Player") {
				if (canEndPush) {
					StopAllCoroutines ();
					canStartPush = true;
				}
			}
		}
	}

	IEnumerator RotateMirror(Collision player){
		yield return new WaitForSeconds (.5f);
		rotateBy = 45;
		canEndPush = false;
		float difX = player.transform.position.x - transform.position.x;
		float difZ = player.transform.position.z - transform.position.z;
		float difC = player.transform.position.z - player.contacts [0].point.z;
		if (rotateY == 0) {
			if (difX * difZ < 0) {
				rotateBy = -45;
			}
		} else if (rotateY == 90) {
			if (difX * difZ > 0) {
				rotateBy = -45;
			}
		} else {
			if (difX * difC< 0) { //45 & 135
				rotateBy = -45;
			}
		}

		rotateY = mod ((rotateY + rotateBy), 180);
		rotate1 = rotateBy / 10f;
		for (int x = 0; x < 10; x++) {
			transform.Rotate (0, rotate1, 0);
			yield return new WaitForSeconds (.002f);
		}


		canStartPush = true;
		canEndPush = true;

	}

	int mod(int x, int m){
		return (x%m + m)%m;
	}
}
