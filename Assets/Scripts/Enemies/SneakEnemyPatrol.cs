using UnityEngine;
using System.Collections;

public class SneakEnemyPatrol : SneakEnemyBase {

	void Awake() {
		patrolMission = new PatrolMission(this);
	}

	void OnDrawGizmos() {
		if(patrolMission == null) return;
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(patrolMission.target, 1f);
	}
}