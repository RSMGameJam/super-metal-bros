using UnityEngine;
using System.Collections;

public class GUITimer : MonoBehaviour {

    Timer timer;

	// Use this for initialization
	void Start () {
        timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
        guiText.text = timer.GetTimeLeft();
    }
}
