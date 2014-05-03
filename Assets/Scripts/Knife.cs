using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {
	
	public Enemy KnifeTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemies")) {
		//if (col.gameObject.tag == "Enemy") {
			KnifeTarget = col.gameObject.GetComponent<Enemy>();
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemies")) {
		//if (col.gameObject.tag == "Enemy") {
				KnifeTarget = null;
			}
	}
}
