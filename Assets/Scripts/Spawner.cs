using UnityEngine;
using System.Collections;

public enum Direction {
	LEFT,
	RIGHT
}

public class Spawner : MonoBehaviour
{
	public float minRespawnTime = 3f;
	public float maxRespawnTime = 7f;
	public GameObject[] enemies;
	public Direction direction;

	private Enemy latestEnemy;

	void Start ()
	{
		//Spawn();
		InvokeRepeating("Spawn", 0f, Random.Range(minRespawnTime, maxRespawnTime));
	}

	void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		GameObject go = Instantiate(enemies[enemyIndex], transform.position, transform.rotation) as GameObject;
		if(direction == Direction.LEFT)
			go.transform.localScale = new Vector3(-go.transform.localScale.x, go.transform.localScale.y, go.transform.localScale.z);
		latestEnemy = go.GetComponent<Enemy>();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.5f);
	}
}
