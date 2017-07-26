using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowAffectRed : MonoBehaviour {
	public Renderer groundShade;
	public Material gMat;


	//rate
	public float glowFadeRate = .97f;
	public float glowFadeTime = .05f;
	public Color groundColor;
	public Color currentGColor = new Color(0f,0f,0f);

	//brightnesslimit
	public float brightnessLimit = 1.2f;
	private Coroutine currentCo = null;
	// Use this for initialization
	void Start () {
		//ground init
		groundShade = GetComponent<Renderer> ();
		gMat = groundShade.material;
		//gMat = groundShade.material;
		gMat.EnableKeyword ("_EMISSION");
		groundShade.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void Glow(float brightness){
		groundShade.enabled = true;
		if (currentCo != null) {
			StopCoroutine (currentCo);
		}
		currentCo = StartCoroutine (GlowFoReal(brightness));
	}
	IEnumerator GlowFoReal(float brightness){
		if (currentGColor.g < brightnessLimit && currentGColor.r < brightnessLimit && currentGColor.b < brightnessLimit) {
			currentGColor += groundColor * brightness;
		}
		for (int x = 0; x < 100; x++) {
			if (currentGColor.r <= 0.1f) {
				groundShade.enabled = false;
				break;
			}
			gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
			currentGColor *= glowFadeRate;
			yield return new WaitForSeconds (glowFadeTime);
		}
	}


}
