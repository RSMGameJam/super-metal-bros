using System;
using System.Collections.Generic;
using System.Text;

namespace Ebbe.Cereal
{
	class Cereal
	{
		private bool _isPaused = false;
		private Queue<ICerealEvent> _actions = new Queue<ICerealEvent>();
		private ICerealEvent _current;

		public void Pause()
		{
			_isPaused = true;
		}

		public void Resume()
		{
			_isPaused = false;
		}

		public void Clear()
		{
			_actions.Clear();
		}

		public void AddAction(Action pAction)
		{
			_actions.Enqueue(new CerealEvent(pAction));
		}

		//public void AddiTween(iTween piTween)
		//{
		//	_actions.Enqueue(new CerealEvent()
		//		{
		//			OnBegin = () =>
		//			{
		//				piTween.Invoke();
		//			},
		//		});
		//}

		public void Add(ICerealEvent e)
		{
			_actions.Enqueue(e);
		}

		public void AddDelay(float pDelay)
		{
			_actions.Enqueue(new CerealDelayEvent(pDelay));
		}

		public void WaitUntil(Func<bool> pCondition)
		{
			_actions.Enqueue(new CerealEvent()
			{
				OnCheckComplete = pCondition,
			});
		}

		public void Log(string message)
		{
			AddAction(() =>
			{
				UnityEngine.Debug.Log(message);
			});
		}

		public void Update()
		{
			if (!_isPaused)
			{
				if (_current == null)
				{
					Next();
				}

				if (_actions.Count > 0 && _current != null)
				{
					_current.Update();

					//UnityEngine.Debug.Log("CHECKING COMPLETE");
					if (_current.CheckComplete())
					{
						Next();
					}
				}
			}

		}

		private void Next()
		{
			// Run the old event's end state
			if (_current != null)
			{
				_current.End();
				_actions.Dequeue();
				
				//UnityEngine.Debug.Log("ENDING " + _current.GetType() + "\n" + DebugLog());
			}

			// Switch to the new event
			if (_actions.Count > 0)
			{
				_current = _actions.Peek();

				if (_current != null)
				{
					// Run the new event's begin state
					_current.Begin();
				}
				else
				{
					// End of events or a null-event which shall not exist
				}
			}
		}

		public string DebugLog()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(string.Format("Cereal contains {0} actions:\n", _actions.Count));
			int i = 1;
			foreach (ICerealEvent e in _actions)
			{
				sb.Append(string.Format("\t{0:00}: {1}\n", i++, e.ToString()));
			}
			return sb.ToString();
		}
	}
}