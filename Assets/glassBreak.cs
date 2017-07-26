using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassBreak : MonoBehaviour {

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
		glassShade.enabled = true;
		if (currentCo != null) {
			StopCoroutine (currentCo);
		}
		currentCo = StartCoroutine (GlowFoReal(brightness));
	}
	IEnumerator GlowFoReal(float brightness){
		currentColor += glassColor * brightness;
		if (currentColor.g > brightnessLimit) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 100, transform.position.z);
		}
		for (int x = 0; x < 100; x++) {
			if (currentColor.g<=0.1f) {
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
		gMat.SetColor ("_EmissionColor", currentColor);
	}
}
