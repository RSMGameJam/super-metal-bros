using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
    public float visionDistance = 3f;
    public float angle = 20f;
    public Vector2 offset;
	public Transform eye;

	Enemy enemy;


	void Start() {
		enemy = GetComponent<Enemy>();
	}

    private void FixedUpdate()
    {
		if(enemy.dead) return;

		// raycasting
		float facing = (transform.localScale.x < 0f ? -1f : 1f);
		Vector2 origin = (Vector2)eye.position + offset*facing;
		Vector2 direction = facing*Vector2.right * transform.localScale.x;
		Ray ray = new Ray(origin, direction);

		RaycastHit2D hit;
		hit = Physics2D.Raycast(ray.origin, ray.direction, visionDistance);
		//Debug.DrawRay(ray.origin, ray.direction  * visionDistance, Color.yellow);
		Debug.DrawRay(ray.origin, ray.direction.normalized * visionDistance, Color.yellow);

		if(hit != null && hit.collider != null) {
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player") || 
				hit.collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
			{
				Player player = hit.collider.GetComponent<Player>();
				if(player != null)
					player.Die();
			}
		}

		//Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		//RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x), visionDistance);
		//Debug.DrawRay((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x * visionDistance), Color.yellow);

		//if(hit != null && hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
		//{
		//	Player player = hit.collider.GetComponent<Player>();
		//	if(player != null)
		//		player.Die();
		//}

		//rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
		//hit = Physics2D.Raycast((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x + offset));
		//Debug.DrawRay((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x * visionDistance ), Color.yellow);

		//if(hit != null && hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
		//{
		//	Player player = hit.collider.GetComponent<Player>();
		//	if(player != null)
		//		player.Die();
		//}
    }

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, transform.position + transform.right);
	}
}
