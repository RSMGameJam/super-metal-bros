using System;
using System.Collections;
using UnityEngine;

public class CerealLerpEvent<T> : ICerealEvent {

	protected ITimeProvider timeProvider = new DefaultTimeProvider();

	public delegate T LerpProvider(T pFrom, T pTo, float pProgress);

	private LerpProvider Lerp;
	public Action<T> OnChange;

	private T _from;
	private T _to;

	private float _duration;
	//private float _endTime;

	float _startTime;

	public CerealLerpEvent(T pFrom, T pTo, float pDuration, LerpProvider pLerp) {
		_from = pFrom;
		_to = pTo;
		_duration = pDuration;
		//_endTime = timeProvider.time + pDuration;
		Lerp = pLerp;
	}

	public void Begin()
	{
		timeProvider.Update();
		_startTime = timeProvider.time;
	}

	float _progress;
	public void Update()
	{
		// Updating the timeProvider
		timeProvider.Update();

		// Update progress of lerp
		_progress = Mathf.Clamp01((timeProvider.time - _startTime) / _duration);

		//Debug.Log("Progress: " + _progress);
		
		T newVal = Lerp(_from, _to, _progress);

		if(OnChange != null)
		{
			OnChange(newVal);
		}
	}

	public void End()
	{
	}

	public bool CheckComplete()
	{
		//Debug.Log("Lerp check complete. time: " + timeProvider.time + ", start: " + _startTime + ", duration: " + _duration);
		return (timeProvider.time - _startTime) >= _duration;
	}

	public override string ToString()
	{
		return string.Format("[{0}] {1} >> {2} in {3:00.00} s", this.GetType().Name, _from, _to, _duration);
	}
}