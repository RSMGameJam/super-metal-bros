using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	void Update() {
		if(Input.anyKeyDown)
		{
			Application.LoadLevel(1);
		}
	}
}