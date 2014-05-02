using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}