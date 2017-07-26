using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStartMarching : MonoBehaviour {
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
	public GameObject enemy17;
	public GameObject enemy18;
	public GameObject enemy19;
	public GameObject enemy20;
	public GameObject enemy21;
	public GameObject enemy22;
	public GameObject enemy23;
	public GameObject enemy24;
	public GameObject enemy25;
	public GameObject enemy26;
	public GameObject enemy27;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collided){
		if (collided.tag == "Player") {
			enemy19.SetActive (true);
			enemy20.SetActive (true);
			enemy21.SetActive (true);
			enemy22.SetActive (true);
			enemy23.SetActive (true);
			enemy24.SetActive (true);
			enemy25.SetActive (true);
			enemy26.SetActive (true);
			enemy27.SetActive (true);

			enemy1.SendMessage ("StartMarching");
			enemy2.SendMessage ("StartMarching");
			enemy3.SendMessage ("StartMarching");
			enemy4.SendMessage ("StartMarching");
			enemy5.SendMessage ("StartMarching");
			enemy6.SendMessage ("StartMarching");
			enemy7.SendMessage ("StartMarching");
			enemy8.SendMessage ("StartMarching");
			enemy9.SendMessage ("StartMarching");
			enemy10.SendMessage ("StartMarching");
			enemy11.SendMessage ("StartMarching");
			enemy12.SendMessage ("StartMarching");
			enemy13.SendMessage ("StartMarching");
			enemy14.SendMessage ("StartMarching");
			enemy15.SendMessage ("StartMarching");
			enemy16.SendMessage ("StartMarching");
			enemy17.SendMessage ("StartMarching");
			enemy18.SendMessage ("StartMarching");
			enemy19.SendMessage ("StartMarching");
			enemy20.SendMessage ("StartMarching");
			enemy21.SendMessage ("StartMarching");
			enemy22.SendMessage ("StartMarching");
			enemy23.SendMessage ("StartMarching");
			enemy24.SendMessage ("StartMarching");
			enemy25.SendMessage ("StartMarching");
			enemy26.SendMessage ("StartMarching");
			enemy27.SendMessage ("StartMarching");
		}
	}
	void Reset(){
		StartCoroutine (ResetHelper());
	}
	IEnumerator ResetHelper (){
		yield return new WaitForEndOfFrame();
		enemy19.SetActive (false);
		enemy20.SetActive (false);
		enemy21.SetActive (false);
		enemy22.SetActive (false);
		enemy23.SetActive (false);
		enemy24.SetActive (false);
		enemy25.SetActive (false);
		enemy26.SetActive (false);
		enemy27.SetActive (false);
	}
}
