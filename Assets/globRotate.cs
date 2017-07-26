using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globRotate : MonoBehaviour {
	public float rotateSpeedX = 2f;
	public float rotateSpeedZ = 1f; 
	public float randomRotateX = 45f;
	public float randomRotateZ = 45f;
	public float randomGrowth;
	public float maxGrowth = 1.5f;
	public float minGrowth = .6f;
	public float maxSwing = 45f;
	public bool canRotate;
	// Use this for initialization
	void Start () {
		randomRotateX = UnityEngine.Random.Range(-maxSwing,maxSwing);
		randomRotateZ = UnityEngine.Random.Range(-maxSwing,maxSwing);
		randomGrowth = UnityEngine.Random.Range (minGrowth, maxGrowth);
		transform.localScale *= randomGrowth;
	}
	
	// Update is called once per frame
	void Update () {
		if (canRotate) {
			transform.rotation = Quaternion.Euler ((randomRotateX * Mathf.Sin (Time.time * rotateSpeedX * 2)), 0f, (randomRotateZ * Mathf.Sin (Time.time * rotateSpeedZ * 2)));
		}
	}
}
