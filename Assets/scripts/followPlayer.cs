using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
	public Transform player;
	public Vector3 distanceFromPlayer = new Vector3(0f, 10f, 0f);
	public float maxheight = 1000f;
	public float minheight = -1000f;
	public float maxwidth = 1000f;
	public float minwidth = -1000f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position + distanceFromPlayer;
		if (transform.position.z > maxheight) {
			transform.position = new Vector3(transform.position.x, transform.position.y, maxheight);
		} else if (transform.position.z < minheight) {
			transform.position = new Vector3(transform.position.x, transform.position.y, minheight);
		}if (transform.position.x > maxwidth) {
			transform.position = new Vector3(maxwidth, transform.position.y, transform.position.z);
		}else if (transform.position.x < minwidth) {
			transform.position = new Vector3(minwidth, transform.position.y, transform.position.z);
		}
	}
}
