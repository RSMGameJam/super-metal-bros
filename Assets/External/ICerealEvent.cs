using System;
using System.Collections;

interface ICerealEvent {
	void Begin();
	void Update();
	void End();
	bool CheckComplete();
}