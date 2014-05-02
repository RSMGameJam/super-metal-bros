using UnityEngine;
using System.Collections;

public class SneakEnemyPatrol : SneakEnemyBase {

	public float leftBorder = 0f;
	public float rightBorder = 0f;

	void Awake() {
		patrolMission = new PatrolMission(this);
	}

	void OnDrawGizmos() {
		if(patrolMission == null || patrolMission.target == default(Vector2)) return;
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(patrolMission.target, 0.4f);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Vector2 left = new Vector2(leftBorder, transform.position.y);
		Gizmos.DrawLine(left+Vector2.up*10f, left-Vector2.up*10f);

		Gizmos.color = Color.blue;
		Vector2 right = new Vector2(rightBorder, transform.position.y);
		Gizmos.DrawLine(right+Vector2.up*10f, right-Vector2.up*10f);
	}
}