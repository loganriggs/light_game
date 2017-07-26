using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenGlass: MonoBehaviour {
	public Renderer groundShade;
	public Material gMat;
	public Rigidbody rb;
	public float shootRange = 5f;

	//rate
	public float glowFadeRate = .97f;
	public float glowFadeTime = .05f;
	public Color groundColor;
	public Color currentGColor = new Color(0f,0f,0f);

	//brightnesslimit
	public float brightnessLimit = 1.2f;
	// Use this for initialization
	void Start () {
		//ground init
		//groundShade = GetComponent<Renderer> ();
		gMat = groundShade.material;
		//gMat = groundShade.material;
		gMat.EnableKeyword ("_EMISSION");
		//rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector3 (Random.Range (-shootRange,shootRange), Random.Range (-shootRange/3f, shootRange/3f), Random.Range (-shootRange, shootRange)));
		//rb.velocity = new Vector3 (Random.Range (-shootRange,shootRange), Random.Range (-shootRange/3f, shootRange/3f), Random.Range (-shootRange, shootRange));
		//Debug.Log (rb.velocity);
		StartCoroutine (FadeAndGo ());
	}
	IEnumerator FadeAndGo(){
		float fadeTime = Random.Range (.01f, .04f);
		currentGColor += groundColor;
		currentGColor *= 5f;
		gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
		for (int iter = 0; iter < 10; iter++) {
			for (int x = 0; x < 10; x++) {
				gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
				currentGColor *= glowFadeRate;
				yield return new WaitForSeconds (fadeTime);
			}
			for (int x = 0; x < 10; x++) {
				gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
				currentGColor /= glowFadeRate;
				yield return new WaitForSeconds (fadeTime);
			}
			currentGColor *= .9f;
			//rb.velocity *= .7f;
		}
		for (int x = 0; x < 1000; x++) {
			if (currentGColor.g <= 0.1f) {
				Destroy (gameObject);
			}
			gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
			currentGColor *= glowFadeRate;
			yield return new WaitForSeconds (glowFadeTime);
		}
	}


}
