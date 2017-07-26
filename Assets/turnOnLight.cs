using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnLight : MonoBehaviour {
	bool lightOn = true;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	public GameObject enemy6;
	public GameObject enemy7;
	public GameObject enemy8;
	public GameObject enemy9;
	public GameObject enemy10;
	public GameObject enemy11;
	public GameObject enemy12;
	public GameObject enemy13;
	public GameObject enemy14;
	public GameObject enemy15;
	public GameObject enemy16;
	public GameObject eText;

	void OnTriggerStay(Collider collided){
		if (collided.tag == "Player" && lightOn) {
			eText.SetActive (true);
			if (Input.GetButtonDown("Toggle")){
				lightOn = false;
				enemy1.SendMessage ("Blind");
				enemy2.SendMessage ("Blind");
				enemy3.SendMessage ("Blind");
				enemy4.SendMessage ("Blind");
				enemy5.SendMessage ("Blind");
				enemy6.SendMessage ("Blind");
				enemy7.SendMessage ("Blind");
				enemy8.SendMessage ("Blind");
				enemy9.SendMessage ("Blind");
				enemy10.SendMessage ("Blind");
				enemy11.SendMessage ("Blind");
				enemy12.SendMessage ("Blind");
				enemy13.SendMessage ("Blind");
				enemy14.SendMessage ("Blind");
				enemy15.SendMessage ("Blind");
				enemy16.SendMessage ("Blind");
			}
		}
	}
	void OnTriggerExit(Collider collided){
		eText.SetActive (false);
	}
	void Reset(){
		lightOn = true;
		eText.SetActive (false);
	}
}
