using System;
using System.Collections;

public class CerealEvent : ICerealEvent {

	protected ITimeProvider timeProvider = new DefaultTimeProvider();

	public Action OnBegin;
	public Action OnUpdate;
	public Action OnEnd;
	public Func<bool> OnCheckComplete = () => true;

	public CerealEvent() {}

	public CerealEvent(Action action) {
		OnBegin = action;
	}
	
	public void Begin() {
		if(OnBegin != null)
		{
			OnBegin.Invoke();
		}
	}

	public void Update() {
		// Updating the timeProvider
		timeProvider.Update();

		if(OnUpdate != null)
		{
			OnUpdate.Invoke();
		}
	}

	public void End() {
		if(OnEnd != null)
		{
			//UnityEngine.Debug.Log("ENDED");
			OnEnd.Invoke();
		}
	}

	public virtual bool CheckComplete() {
		//UnityEngine.Debug.Log("CHECK COMPLETE: " + OnCheckComplete.Invoke());
		return OnCheckComplete.Invoke();
	}

	public override string ToString()
	{
		return this.GetType().Name;
	}
}