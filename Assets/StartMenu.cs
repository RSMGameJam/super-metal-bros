using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Rect levelOneButton;

	void OnGUI() {
		if(GUI.Button(levelOneButton, "Level One"))
		{
			Application.LoadLevel(1);
		}
	}
}