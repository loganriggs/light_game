using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshCombiner : MonoBehaviour {
	public MeshFilter[] meshFilters;

	void Start() {
		Transform[] myKids = GetComponentsInChildren<Transform>();
		Transform[] temp = GetComponentsInChildren<Transform>();;
		foreach(Transform kids in myKids){
			//while (temp[1].tag != "glowObject") {
			//	temp = kids.GetComponentsInChildren<Transform>();
			//}
			//meshFilters = 
		}

		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		int i = 0;
		while (i < meshFilters.Length) {
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.active = false;
			i++;
		}
		transform.GetComponent<MeshFilter>().mesh = new Mesh();
		transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		transform.gameObject.active = true;
	}
}
