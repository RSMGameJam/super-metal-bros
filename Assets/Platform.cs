using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Platform : MonoBehaviour {

	public int tiles = 1;
	public GameObject prefab;

	private List<GameObject> tileObjects = new List<GameObject>();

	void Update () {
		if(prefab == null) return;

		//Debug.Log("tiles: " + tiles + ", count: " + tileObjects.Count);
		if(tiles != tileObjects.Count) {
			// Destroy old tiles
			foreach(GameObject go in tileObjects) {
				DestroyImmediate(go);
			}
			tileObjects.Clear();

			// Create new tiles
			Vector3 pos = transform.position;
			for(int i = 0; i < tiles; ++i) {

				GameObject go = Instantiate(prefab, pos + Vector3.right*(i+1), Quaternion.identity) as GameObject;
				go.name = string.Format("tile_{0:00}", i);
				go.transform.parent = transform;
				tileObjects.Add(go);
			}
		}
	}
}
