using UnityEngine;
using System.Collections;

public class GameOverState : MonoBehaviour {

    public GameObject GameOverText;

    private Spawner[] spawners;
    private Timer timer;

	// Use this for initialization
	void Start () {
        spawners = GameObject.FindObjectsOfType<Spawner>();
        timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer.TimeLeft <= 0)
        {
            foreach (Spawner spawn in spawners)
            {
                spawn.gameObject.SetActive(false);
            }
            GameOverText.SetActiveRecursively(true);
        }
	}
}
