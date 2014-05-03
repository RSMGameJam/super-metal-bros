using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float respawnTime = 5f;
	public GameObject[] enemies;

	private Enemy latestEnemy;

	void Start ()
	{
		Spawn();
	}

<<<<<<< HEAD
=======
	void Update() {
		// No enemy alive, spawn new after timer
		if(latestEnemy == null)
		{
			Invoke("Spawn", respawnTime);
		}
	}

>>>>>>> 93c524fbd0843a08ce0681bf957fa336acc50903
	void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		GameObject go = Instantiate(enemies[enemyIndex], transform.position, transform.rotation) as GameObject;
		latestEnemy = go.GetComponent<Enemy>();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.5f);
	}
}
