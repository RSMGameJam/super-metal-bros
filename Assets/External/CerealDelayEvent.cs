using System;
using System.Collections;
using UnityEngine;

public class CerealDelayEvent : CerealEvent {

	private double _duration;
	private double _endTime;

	public CerealDelayEvent(double duration) {
		_duration = duration;
		_endTime = timeProvider.time + duration;

		UnityEngine.Debug.Log("SETTING THE REAL ONE");
		OnCheckComplete = () => {
			return timeProvider.time >= _endTime;
		};

		UnityEngine.Debug.Log("ONCHECKCOMPLETE: " + OnCheckComplete);
	}

	public override string ToString()
	{
		return string.Format("{0}, {1:00.00} s duration", this.GetType().Name, _duration);
	}
}