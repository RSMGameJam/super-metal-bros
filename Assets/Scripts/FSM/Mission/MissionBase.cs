using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MissionBase {

	public Func<bool> CheckFinished;
	public Action OnFinished;

	public bool Update() {
		if(CheckFinished.Invoke())
		{
			OnFinished.Invoke();
			return true;
		}
		else
			return false;
	}
}