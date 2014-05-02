using UnityEngine;
using System.Collections;

public class SneakEnemyBase : StateMachineBehaviourEx {

	public enum EnemyStates {
		Patrol,
		Detected,
		Hit
	}

	public float health;
	public float walkSpeed;

	[SerializeField]public MissionBase mission;

	protected override void OnAwake() {
		
	}

	IEnumerator Patrol_EnterState() {
		health = 100f;
		yield return null;
	}

	IEnumerator Patrol_Update() {
		// Update mission
		mission.Update();

		// Is player in sight?

		// Player detected

		// If not, patrol
		yield return null;
	}

	IEnumerator Patrol_ExitState() {
		yield return null;
	}
}
