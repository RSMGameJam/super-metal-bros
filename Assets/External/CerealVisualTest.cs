using UnityEngine;
using System.Collections;
using Ebbe.Cereal;

public class CerealVisualTest : MonoBehaviour {

	public GameObject affectedObject;

	Cereal kelloggs = new Cereal();
	bool isDoneWaiting;

	void Start() {
		Test();
	}

	void Test() {
		kelloggs.Clear();

		// Shrink the cube
//		Shrink();

		// Blow the cube as a letter box
		Blow();

		// Print the action queue
		Debug.Log(kelloggs.DebugLog());
	}

	void Shrink() {

		kelloggs.Log("Start shrinking");

		// Shrink with animation
//		kelloggs.AddAction(() => {
//			affectedObject.animation.Play();
//		});
//		kelloggs.WaitUntil(() => !affectedObject.animation.isPlaying);

		// Shrink with iTween
		//kelloggs.AddiTween(() => iTween.ScaleTo(affectedObject, Vector3.zero, 1f));

		kelloggs.Log("Done shrinking");
	}

	void Blow() {

		// Shrink

		// Particle effect

		// Screen shake

		// Sound effect

		// Wait until shrunk

		// Score grows

		// Add multiplier

		// Count up

		// Go to score counter

	}

	void Update() {
		kelloggs.Update();
	}
}