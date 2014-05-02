using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PatrolMission : MissionBase {

	const float CLOSE_ENOUGH = 10f;
	const float MAX_DISTANCE = 200f;

	public SneakEnemy enemy;
	public Vector2 target;

	public PatrolMission(SneakEnemy pEnemy) {
		enemy = pEnemy;
		target = RandomizeNewTarget();

		CheckFinished = () => {
			if(Vector2.Distance(enemy.transform.position, target) < CLOSE_ENOUGH) {
				Debug.Log("CLOSE ENOUGH");
				enemy.transform.position = target;

				// Randomize new target
				target = RandomizeNewTarget();

				return true;
			}
			else {
				Debug.Log("WALKING");
				WalkTowardsTarget();
				return false;
			}
		};
	}

	private void WalkTowardsTarget() {
		float direction = ((target - (Vector2)enemy.transform.position).sqrMagnitude < 0f ? -1f : 1f);
		enemy.rigidbody2D.velocity += new Vector2(enemy.walkSpeed * Time.deltaTime * direction, enemy.rigidbody2D.velocity.y);
		Debug.Log("New velocity: " + (enemy.walkSpeed * Time.deltaTime * direction));
	}

	private Vector2 RandomizeNewTarget() {
		if(target == null)
			target = enemy.transform.position;

		Vector2 newTarget = target;

		do {
			newTarget.x = newTarget.x + UnityEngine.Random.Range(-MAX_DISTANCE, MAX_DISTANCE);
		} while(Physics2D.Raycast(newTarget, -enemy.transform.up).collider != null);

		return newTarget;
	}
}