using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowTree : MonoBehaviour {

	public Renderer glassShade;
	public Material gMat;


	//rate
	public float glowFadeRate = .97f;
	public float glowFadeTime = .05f;
	public Color glassColor;

	//breakrate
	public float brightnessLimit = 2f;
	private Coroutine currentCo = null;
	public Color currentColor = new Color (0f, 0f, 0f);

	//reset
	public Vector3 originalPosition;

	//shoot
	public Rigidbody echoTree;

	//bool
	public bool done;
	// Use this for initialization
	void Start () {
		//glass init
		glassShade = GetComponent<Renderer> ();
		gMat = glassShade.material;
		gMat.EnableKeyword ("_EMISSION");
		originalPosition = transform.position;
		glassShade.enabled = false;

	}

	// Update is called once per frame
	void Update () {

	}

	void Glow(float brightness){
		if (!done) {
			glassShade.enabled = true;
			if (currentCo != null) {
				StopCoroutine (currentCo);
			}
			currentCo = StartCoroutine (GlowFoReal (brightness));
		}
	}
	IEnumerator GlowFoReal(float brightness){
		currentColor += glassColor * brightness*2f;
		if (currentColor.b > brightnessLimit) {
			done = true;
			Vector3 pos = transform.position - new Vector3(0f, transform.position.y-1f, 0f);
			Instantiate (echoTree, pos, transform.rotation);

			for (int x = 0; x < 4; x++) {
				if (currentColor.b<=0.2f) {
					glassShade.enabled = false;
				}
				gMat.SetColor ("_EmissionColor", currentColor * glowFadeRate*.5f);
				currentColor *= glowFadeRate;
				yield return new WaitForSeconds (glowFadeTime);
				gameObject.SetActive (false);
			}
		}
		for (int x = 0; x < 100; x++) {
			if (currentColor.b<=0.1f) {
				glassShade.enabled = false;
				break;
			}
			gMat.SetColor ("_EmissionColor", currentColor * glowFadeRate);
			currentColor *= glowFadeRate;
			yield return new WaitForSeconds (glowFadeTime);
		}
	}
	void Reset(){
		if (currentCo != null) {
			StopCoroutine (currentCo);
		}
		transform.position = originalPosition;
		currentColor = new Color (0f,0f,0f);
		gMat.SetColor ("_EmissiwonColor", currentColor);
	}
}
