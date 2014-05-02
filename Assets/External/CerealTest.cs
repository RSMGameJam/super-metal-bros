using UnityEngine;
using System.Collections;
using Ebbe.Cereal;

public class CerealTest : MonoBehaviour {

	// Cereal kelloggs = new Cereal(timeProvider);	// Test with customized time provider
	Cereal kelloggs = new Cereal();
	bool isDoneWaiting;

	void Start() {
		kelloggs.Clear();

		SerialTest();
		WaitTest();
		CombinedTest();

		Debug.Log(kelloggs.DebugLog());
	}

	void SerialTest() {
		kelloggs.AddAction(() => { Debug.Log("ONE"); });
		kelloggs.AddAction(() => { Debug.Log("TWO"); });
		kelloggs.AddAction(() => { Debug.Log("THREE"); });
		kelloggs.AddAction(() => { Debug.Log("FOUR"); });
		kelloggs.AddAction(() => { Debug.Log("FIVE"); });
	}

	void WaitTest() {
		kelloggs.AddAction(() => { Debug.Log("BEFORE WAIT"); });
		kelloggs.AddDelay(8f);
		kelloggs.AddAction(() => { Debug.Log("WAITED 8 SEC!"); });
		kelloggs.WaitUntil(() => isDoneWaiting);
	}

	void CombinedTest() {
		kelloggs.AddAction(() => { Debug.Log("ONE"); });
		kelloggs.AddAction(() => { Debug.Log("TWO"); });
		kelloggs.AddAction(() => { Debug.Log("THREE"); });
		kelloggs.AddAction(() => { Debug.Log("Waiting 3 seconds"); });
		kelloggs.AddDelay(3f);
		kelloggs.AddAction(() => { Debug.Log("Resuming!"); });
		kelloggs.AddAction(() => { Debug.Log("FOUR"); });
		kelloggs.AddAction(() => { Debug.Log("FIVE"); });
	}

	void Update() {
		kelloggs.Update();
	}
}