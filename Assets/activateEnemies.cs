using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateEnemies : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collided){
		if (collided.tag == "Player") {
			enemy1.GetComponent<enemySeeScript> ().destination = transform.position;
			enemy1.SendMessage ("MoveTowardsAlarm", 0f);
			enemy2.GetComponent<enemySeeScript> ().destination = transform.position;
			enemy2.SendMessage ("MoveTowardsAlarm", 4f);
			enemy3.GetComponent<enemySeeScript> ().destination = transform.position;
			enemy3.SendMessage ("MoveTowardsAlarm", 4f);
		}
	}
}
