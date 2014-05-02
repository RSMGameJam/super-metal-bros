using UnityEngine;
using System.Collections;

public class SneakEnemyPatrol : SneakEnemyBase {

	protected override void OnAwake() {
		currentState = EnemyStates.Patrol;

		base.OnAwake();
		
		mission = new PatrolMission(this);
	}
}