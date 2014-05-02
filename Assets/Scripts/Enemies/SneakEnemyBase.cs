using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SneakEnemyBase : MonoBehaviour {

	public enum EnemyStates {
		Patrol,
		Detected,
		Hit
	}

	public EnemyStates current = EnemyStates.Patrol;

	public float health = 100f;
	public float walkSpeed;

	public PatrolMission patrolMission;

	public void Update() {
		switch(current) {
			case EnemyStates.Detected:

				break;

			case EnemyStates.Hit:

				break;

			case EnemyStates.Patrol:
				// Update mission
				patrolMission.UpdateMission();

				// Is player in sight?

				// Player detected

				// If not, patrol
				break;
		}
	}
}
