using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
    public float visionDistance = 3f;
    public float angle = 20f;
    public Vector2 offset;

    private void FixedUpdate()
    {
		RaycastHit2D hit;
		hit = Physics2D.Raycast((Vector2)this.transform.position + offset, (transform.localScale.x < 0f ? -1f : 1f)*Vector2.right * transform.localScale.x, visionDistance);
		Debug.DrawRay((Vector2)this.transform.position + offset, (transform.localScale.x < 0f ? -1f : 1f)*Vector2.right  * visionDistance, Color.yellow);

		if(hit != null && hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
			Player player = hit.collider.GetComponent<Player>();
			if(player != null)
				player.Die();
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
}
