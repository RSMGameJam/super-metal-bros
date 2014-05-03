using UnityEngine;
using System.Collections;
using Ebbe.Cereal;

public class Score : MonoBehaviour
{
	public float countUpDuration = 1f;

	[HideInInspector]public int score = 0;	// The player's score.

	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.

	private Cereal _cereal = new Cereal();

	public void AddScore(int pAddScore) {
		score += pAddScore;
		_cereal.Clear();
		_cereal.Add(new CerealLerpEvent<float>(previousScore, (float)score, countUpDuration, Mathf.Lerp)
		{
			OnChange = (pChange) => {
				guiText.text = "Score: " + (int)pChange;
			}
		});
		previousScore = score;
	}

	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

		// Set empty score
		guiText.text = "Score: " + score;
	}

	void Update ()
	{
		_cereal.Update();
	}
}