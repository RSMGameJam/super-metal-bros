﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Platform : MonoBehaviour {

	const float edgeFixColliderWidth = 0.25f;

	public PhysicsMaterial2D mainMaterial;
	public PhysicsMaterial2D edgeMaterial;

	public int tiles = 1;
	public GameObject prefab;

	public float edgeFixOffset = 0.1f;

	public bool manualRebuild = false;

	[SerializeField]private List<GameObject> tileObjects = new List<GameObject>();

	[SerializeField]
	private BoxCollider2D col;
	[SerializeField]private GameObject leftEdgeFix;
	[SerializeField]private GameObject rightEdgeFix;

	void CreateEdgeFixes() {

		manualRebuild = false;
		
		if(leftEdgeFix != null)
			DestroyImmediate(leftEdgeFix.gameObject);

		if(rightEdgeFix != null)
			DestroyImmediate(rightEdgeFix.gameObject);

		// HAXX: Fix the edges of the platform
		
		// Left
		leftEdgeFix = new GameObject();
		leftEdgeFix.AddComponent<BoxCollider2D>().transform.localScale = new Vector3(edgeFixColliderWidth, 1f, 1f);
		leftEdgeFix.GetComponent<BoxCollider2D>().sharedMaterial = edgeMaterial;
		leftEdgeFix.name = "EdgeFix_left";
		leftEdgeFix.transform.parent = transform;
		leftEdgeFix.transform.localPosition = Vector2.zero - Vector2.right*(edgeFixOffset+0.5f-0.125f) - Vector2.up*edgeFixOffset;

		// Right
		rightEdgeFix = new GameObject();
		rightEdgeFix.AddComponent<BoxCollider2D>().transform.localScale = new Vector3(edgeFixColliderWidth, 1f, 1f);
		rightEdgeFix.GetComponent<BoxCollider2D>().sharedMaterial = edgeMaterial;
		rightEdgeFix.name = "EdgeFix_right";
		rightEdgeFix.transform.parent = transform;
		rightEdgeFix.transform.localPosition = Vector2.zero + Vector2.right*(edgeFixOffset+tileObjects.Count-1f+0.5f-0.125f) - Vector2.up*edgeFixOffset;
	}

	void Update () {
		if(prefab == null) return;

		// Edge fixes
		if(manualRebuild || leftEdgeFix == null || rightEdgeFix == null)
		{
			CreateEdgeFixes();
		}

		//Debug.Log("tiles: " + tiles + ", count: " + tileObjects.Count);
		if(manualRebuild || tiles != tileObjects.Count) {
			// Destroy old tiles
			foreach(GameObject go in tileObjects) {
				DestroyImmediate(go);
			}
			tileObjects.Clear();

			// Create new tiles
			Vector3 pos = transform.position;
			for(int i = 0; i < tiles; ++i) {

				GameObject go = Instantiate(prefab, pos + Vector3.right*i, Quaternion.identity) as GameObject;
				//go.GetComponent<BoxCollider2D>().sharedMaterial = mainMaterial;	
				go.name = string.Format("tile_{0:00}", i);
				go.transform.parent = transform;
				tileObjects.Add(go);
			}



			// Update collider
			if(manualRebuild)
			{
				DestroyImmediate(col);
				col = null;
			}

			if(col == null) {
				col = gameObject.AddComponent<BoxCollider2D>();
			}
			else {
				BoxCollider2D boxCol = col.GetComponent<BoxCollider2D>();
				if(boxCol != null)
					col = boxCol;
				else
					col = gameObject.AddComponent<BoxCollider2D>();
			}
			col.sharedMaterial = mainMaterial;
			col.size = new Vector2(tileObjects.Count, 1f);
			col.center = new Vector2(tileObjects.Count/2f - 0.5f, 0f);

			// Update position right edge fix
			rightEdgeFix.transform.localPosition = Vector2.zero + Vector2.right*(edgeFixOffset+tileObjects.Count-1f+0.5f-0.125f) - Vector2.up*edgeFixOffset;
		}
	}
}