using System;
using System.Collections;

public class WordfallTimeProvider : ITimeProvider {

	private Func<float> _timeProvider;

	public float time { get; set; }
	public float deltaTime { get; set; }

	// Default time provider is Unity time
	public WordfallTimeProvider() : this(() => UnityEngine.Time.time) {}

	public WordfallTimeProvider(Func<float> timeProvider)
	{
		_timeProvider = timeProvider;

		time = _timeProvider.Invoke();
		deltaTime = 0f;
	}

	public void Update() {
		// Calculate new delta time and update the time variable
		deltaTime = _timeProvider.Invoke() - time;
		time = _timeProvider.Invoke();
	}
}