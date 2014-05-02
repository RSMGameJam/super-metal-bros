using UnityEngine;
using System.Collections;

public class SneakEnemy : SneakEnemyBase {

	protected override void OnAwake() {
		base.OnAwake();

		mission = new PatrolMission(this);
	}
}