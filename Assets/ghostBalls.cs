using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBalls : MonoBehaviour {
	public float speed = 2f; 
	// Use this for initialization
	void Start () {
		speed = Random.Range (2f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		float size = Mathf.Sin (speed * Time.time); 
		transform.localScale = new Vector3(size,size,size);
	}
}
