using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class LevelBuilder: EditorWindow{

	string width = " ";
	string height = " ";
	bool staggered;
	float shift = 0;
	Transform originalParent;
	float dist = Mathf.Sqrt(2);

	[MenuItem ("Window/Level Builder")]



	public static void ShowWindow(){
		EditorWindow.GetWindow (typeof(LevelBuilder));
	}

	void OnGUI(){
		width = EditorGUILayout.TextField ("Width:", width);
		height = EditorGUILayout.TextField ("Height:", height);
		staggered = EditorGUILayout.Toggle (staggered);

		if (Selection.activeTransform) {
			GUILayout.Label ("Selected: " + Selection.activeTransform.name);
			originalParent = Selection.activeTransform.parent;
		} else {
			GUILayout.Label ("Selected: None");
		}
		if (GUILayout.Button ("Press me")) {
			/*
			 if (staggered) {
				GameObject parent = new GameObject ();
				parent.name = Selection.activeTransform.name + height + "x" + width;
				parent.transform.SetParent (originalParent);
				for (int rows = 0; rows < int.Parse (height); rows++) {
					for (int columns = 0; columns < int.Parse (width); columns++) {
						Object prefabRoot = EditorUtility.GetPrefabParent (Selection.activeGameObject);
						GameObject prefab = PrefabUtility.InstantiatePrefab (prefabRoot as GameObject) as GameObject;
						if (rows % 2 == 1) {//odd
							shift = dist/2.0f;
						} else {
							shift = 0f;
						}
						prefab.transform.localPosition = new Vector3 (prefab.transform.localPosition.x + columns*dist+shift, prefab.transform.localPosition.y, prefab.transform.localPosition.z + rows/2.0f*dist);
						prefab.transform.SetParent (parent.transform);
					}
				}
				parent.transform.localPosition = new Vector3 (0, 0, 0); 
			*/
			if (staggered) {
				GameObject parent = new GameObject ();
				parent.name = Selection.activeTransform.name + height + "x" + width;
				parent.transform.SetParent (originalParent);
				for (int rows = 0; rows < int.Parse (height); rows++) {
					for (int columns = 0; columns < int.Parse (width); columns++) {
						Object prefabRoot = EditorUtility.GetPrefabParent (Selection.activeGameObject);
						GameObject prefab = PrefabUtility.InstantiatePrefab (prefabRoot as GameObject) as GameObject;
						if (rows % 2 == 1) {//odd
							shift = .75f;
						} else {
							shift = 0f;
						}
						prefab.transform.localPosition = new Vector3 (prefab.transform.localPosition.x + columns*1.5f+shift, prefab.transform.localPosition.y, prefab.transform.localPosition.z + rows*3.0f/4.0f);
						prefab.transform.SetParent (parent.transform);
					}
				}
				parent.transform.localPosition = new Vector3 (0, 0, 0);
			} else {
				GameObject parent = new GameObject ();
				parent.name = Selection.activeTransform.name + height + "x" + width;
				parent.transform.SetParent (originalParent);
				for (int rows = 0; rows < int.Parse (height); rows++) {
					for (int columns = 0; columns < int.Parse (width); columns++) {
						Object prefabRoot = EditorUtility.GetPrefabParent (Selection.activeGameObject);
						GameObject prefab = PrefabUtility.InstantiatePrefab (prefabRoot as GameObject) as GameObject;
						prefab.transform.localPosition = new Vector3 (prefab.transform.localPosition.x + columns, prefab.transform.localPosition.y, prefab.transform.localPosition.z + rows);
						prefab.transform.SetParent (parent.transform);
					}
				}
				parent.transform.localPosition = new Vector3 (0, 0, 0);
			}
		}
	}
}
