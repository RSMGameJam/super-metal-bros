using UnityEngine;
using System.Collections;
using System;

public class PatrolMission : MissionBase {

	public SneakEnemyPatrol enemy;
	public Vector2 target;

	float lastDistance = 100000f;

	public PatrolMission(SneakEnemyPatrol pEnemy) {
		enemy = pEnemy;
		target = RandomizeNewTarget();

		CheckFinished = () => {
			float distance = Vector2.Distance(enemy.transform.position, target);
			if(distance > lastDistance) {
				enemy.transform.position = new Vector2(target.x, enemy.transform.position.y);

				// Randomize new target
				target = RandomizeNewTarget();

				lastDistance = 100000f;
				return true;
			}
			else {
				WalkTowardsTarget();
				lastDistance = distance;
				return false;
			}
		};
	}

	private void WalkTowardsTarget() {
		float direction = (target.x > enemy.transform.position.x ? 1f : -1f);
		enemy.rigidbody2D.velocity = new Vector2(enemy.walkSpeed * Time.deltaTime * direction, enemy.rigidbody2D.velocity.y);
		//Debug.Log("New velocity: " + (enemy.walkSpeed * Time.deltaTime * direction));
	}

	private Vector2 RandomizeNewTarget() {
		Vector2 newTarget = enemy.transform.position;
		newTarget.x = UnityEngine.Random.Range(enemy.leftBorder, enemy.rightBorder);

		enemy.transform.localScale = new Vector3(newTarget.x < enemy.transform.position.x ? -1f : 1f, enemy.transform.localScale.y, enemy.transform.localScale.z);

		return newTarget;
	}
}