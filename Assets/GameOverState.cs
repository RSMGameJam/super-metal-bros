using UnityEngine;
using System.Collections;

public class GameOverState : MonoBehaviour {

    public GameObject GameOverText;

    private Spawner[] spawners;
    private Timer timer;

    public float gameEndDelay = 1f;
    private float gameEndTimer = 0;

	bool isGameOver = false;

	// Use this for initialization
	void Start () {
        spawners = GameObject.FindObjectsOfType<Spawner>();
        timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer.TimeLeft <= 0)
        {
			if(!isGameOver)

			{
				foreach (Spawner spawn in spawners)
				{
					spawn.gameObject.SetActive(false);
				}
				GameOverText.SetActiveRecursively(true);
				isGameOver = true;
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject pl in players)
                {
                    PlayerControl ctr = pl.GetComponent<PlayerControl>();
                    if (ctr != null)
                    {
                        ctr.lockControls = true;
                    }
                }
			}

            gameEndTimer += Time.deltaTime;

			if(Input.anyKeyDown && gameEndTimer >= gameEndDelay) {
				StateHandler.state = GameState.LEVELONE;
			}
        }
	}
}
