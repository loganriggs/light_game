using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlock : MonoBehaviour {

	public Renderer glassShade;
	public Material gMat;
	public Color gEmission;


	//rate
	public float glowFadeRate = .97f;
	public float glowFadeTime = .05f;
	public Color glassColor;

	//breakrate
	public float brightnessLimit = 2f;
	private Coroutine currentCo = null;
	public Color currentColor = new Color (0f, 0f, 0f);

	//death scene
	bool alive = true;
	public Rigidbody brokenGlass;
	public bool testGlass = false;

	//reset
	public Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		//glass init
		glassShade = GetComponent<Renderer> ();
		gMat = glassShade.material;
		gMat.EnableKeyword ("_EMISSION");
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

	}

	void Glow(float brightness){
		if (alive) {
			glassShade.enabled = true;
			if (currentCo != null) {
				StopCoroutine (currentCo);
			}
			currentCo = StartCoroutine (GlowFoReal (brightness));
		}
	}
	IEnumerator GlowFoReal(float brightness){
		currentColor += glassColor * brightness;
		if (currentColor.g > brightnessLimit) {
			alive = false;
			for (int x = 0; x < 7; x++) {
				gMat.SetColor ("_EmissionColor", currentColor*.5f*(x));
				yield return new WaitForSeconds (.001f);
			}
			//set broken glass active...explode??
			Vector3 pos = transform.position;
			transform.position = new Vector3 (transform.position.x, transform.position.y - 100, transform.position.z);
			for (int x = 0; x < 100; x++){
				Instantiate (brokenGlass, pos, Quaternion.identity);
			}
			if (testGlass) {
				gMat.SetColor ("_EmissionColor", currentColor*0f);
				currentColor *= 0;
				yield return new WaitForSeconds (5f);
				transform.position = new Vector3 (transform.position.x, transform.position.y + 100, transform.position.z);
				alive = true;
			}
		} else {
			for (int x = 0; x < 200; x++) {
				if (currentColor.g <= 0.3f) {
					//glassShade.enabled = false;
					gMat.SetColor ("_EmissionColor", currentColor * .995f);
					currentColor *= .995f;
					yield return new WaitForSeconds (.01f);
				} else {
					gMat.SetColor ("_EmissionColor", currentColor * glowFadeRate);
					currentColor *= glowFadeRate;
					yield return new WaitForSeconds (glowFadeTime);
				}
			}
		}
	}
	void Reset(){
		if (currentCo != null) {
			StopCoroutine (currentCo);
		}
		transform.position = originalPosition;
		currentColor = new Color (0f,0f,0f);
		gMat.SetColor ("_EmissionColor", currentColor);
	}

	void OnTriggerEnter(Collider collided){
		if (collided.tag == "echo") {
			Destroy (collided);
		}
	}
}
