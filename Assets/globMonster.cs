using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globMonster : MonoBehaviour {
	public Renderer groundShade;
	public Material gMat;
	public Color gEmission;


	//rate
	public float glowFadeRate = .97f;
	public float glowFadeTime = .05f;
	public Color groundColor;
	public Color currentGColor = new Color(0f,0f,0f);

	//parent script
	public globRotate parentScript;

	//brightnesslimit
	public float brightnessLimit = 1.2f;
	private Coroutine currentCo = null;
	// Use this for initialization
	void Start () {
		//ground init
		parentScript = GetComponentInParent<globRotate>();
		groundShade = GetComponent<Renderer> ();
		gMat = groundShade.material;
		gMat.EnableKeyword ("_EMISSION");
		groundShade.enabled = false;
		parentScript.canRotate = false;
	}

	// Update is called once per frame
	void Update () {
	}

	void Glow(float brightness){
		groundShade.enabled = true;
		parentScript.canRotate = true;
		if (currentCo != null) {
			StopCoroutine (currentCo);
		}
		currentCo = StartCoroutine (GlowFoReal(brightness));
	}
	IEnumerator GlowFoReal(float brightness){
		currentGColor += groundColor * brightness;
		if (currentGColor.r > brightnessLimit) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 100, transform.position.z);
			gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate*5);

			groundShade.enabled = false;
			parentScript.canRotate = false;
		}
		for (int x = 0; x < 100; x++) {
			if (currentGColor.r <= 0.0002f) {
				groundShade.enabled = false;
				parentScript.canRotate = false;
				break;
			}
			gMat.SetColor ("_EmissionColor", currentGColor * glowFadeRate);
			currentGColor *= glowFadeRate;
			yield return new WaitForSeconds (glowFadeTime);
		}
	}


}
