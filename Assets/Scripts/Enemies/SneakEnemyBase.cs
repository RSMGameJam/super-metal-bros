using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SneakEnemyBase : StateMachineBehaviourEx {

	public enum EnemyStates {
		Patrol,
		Detected,
		Hit
	}

	public float health;
	public float walkSpeed;

	public MissionBase mission;

	protected override void OnAwake() {
		
	}

	IEnumerator Patrol_EnterState() {
		Debug.Log("ENTERUUUU");
		health = 100f;
		yield return null;
	}

	IEnumerator Patrol_Update() {
		Debug.Log("PATROL UPDATE");
		// Update mission
		mission.UpdateMission();

		// Is player in sight?

		// Player detected

		// If not, patrol
		yield return null;
	}

	IEnumerator Patrol_ExitState() {
		yield return null;
	}
}
