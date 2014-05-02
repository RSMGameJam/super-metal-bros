using System;
using System.Collections;

public class DefaultTimeProvider : ITimeProvider {

	private Func<float> _timeProvider;

	public float time { get; set; }
	public float deltaTime { get; set; }

	// Default time provider is Unity time
	public DefaultTimeProvider() : this(() => UnityEngine.Time.time) {}

	public DefaultTimeProvider(Func<float> timeProvider)
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