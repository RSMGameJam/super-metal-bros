using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MissionBase {

	public Func<bool> CheckFinished;
	public Action OnFinished;

	public bool UpdateMission() {
		if(CheckFinished != null && CheckFinished.Invoke())
		{
			if(OnFinished != null) OnFinished.Invoke();
			return true;
		}
		else
			return false;
	}
}