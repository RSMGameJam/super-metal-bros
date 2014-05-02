using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PatrolMission : MissionBase {

	const float CLOSE_ENOUGH = 0.5f;
	const float MAX_DISTANCE = 10f;

	public SneakEnemyPatrol enemy;
	public Vector2 target;

	public PatrolMission(SneakEnemyPatrol pEnemy) {
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
				WalkTowardsTarget();
				return false;
			}
		};
	}

	private void WalkTowardsTarget() {
		float direction = ((target - (Vector2)enemy.transform.position).sqrMagnitude < 0f ? 1f : -1f);
		enemy.rigidbody2D.velocity = new Vector2(enemy.walkSpeed * Time.deltaTime * direction, enemy.rigidbody2D.velocity.y);
		//Debug.Log("New velocity: " + (enemy.walkSpeed * Time.deltaTime * direction));
	}

	private Vector2 RandomizeNewTarget() {
		if(target == default(Vector2))
			target = enemy.transform.position;

		Vector2 newTarget = target;
		RaycastHit2D hit;
		do {
			newTarget.x = newTarget.x + UnityEngine.Random.Range(-MAX_DISTANCE, MAX_DISTANCE);
			hit = Physics2D.Raycast(newTarget, -enemy.transform.up);
		} while(hit.collider == null && Vector2.Distance(target, hit.point) > 1f);

		return newTarget;
	}
}