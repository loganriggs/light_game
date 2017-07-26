using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowAffectGrass : MonoBehaviour {
	public Renderer groundShade;
	public Material gMat;
	public Color gEmission;

	//rate
	public float glowFadeRate = .97f;
	public float glowFadeTime = .05f;
	public Color groundColor;
	public Color currentGColor = new Color(0f,0f,0f);

	//brightnesslimit
	public float brightnessLimit = 1f;
	private Coroutine currentCo = null;
	// Use this for initialization
	void Start () {
		//ground init
		groundShade = GetComponent<Renderer> ();
		gMat = groundShade.material;
		gMat.EnableKeyword ("_EMISSION");
		groundShade.enabled = false;
	}


	void Glow(float brightness){
		if (currentCo != null) {
			StopCoroutine (currentCo);
		}
		currentCo = StartCoroutine (GlowFoReal(brightness));
	}
	IEnumerator GlowFoReal(float brightness){
		groundShade.enabled = true;
		if (currentGColor.g < brightnessLimit && currentGColor.r < brightnessLimit && currentGColor.b < brightnessLimit) {
			if (brightness > 2) {
				brightness = 1;
			}
			currentGColor += groundColor * brightness;
		}
		for (int x = 0; x < 100; x++) {
			gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
			currentGColor = currentGColor *glowFadeRate;
			if (currentGColor.g <= 0.1f) {
				groundShade.enabled = false;
				break;
			}
			yield return new WaitForSeconds (glowFadeTime);
		}
	}


}
