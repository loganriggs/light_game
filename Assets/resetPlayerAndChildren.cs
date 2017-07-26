using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayerAndChildren : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void PlayerDied(){
		player.SendMessage ("Reset");
		foreach (Transform objectToReset in transform) {
			objectToReset.gameObject.SendMessage ("Reset");
		}
	}
}
