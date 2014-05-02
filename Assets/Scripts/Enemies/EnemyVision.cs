using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
    public float visionDistance = 3f;
    public float angle = 20f;
    public Vector2 offset;

    private void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast((Vector2)this.transform.position + offset, Vector2.right * transform.localScale.x, visionDistance, LayerMask.NameToLayer("Player"));
        Debug.DrawRay((Vector2)this.transform.position + offset, Vector2.right * transform.localScale.x * visionDistance, Color.yellow);

        if (hit != null)
        {
            //Player player = hit.collider.GetComponent<Player>();
            //if (player != null)
            //    player.Die();
        }

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        hit = Physics2D.Raycast((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x), visionDistance, LayerMask.NameToLayer("Player"));
        Debug.DrawRay((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x * visionDistance), Color.yellow);

        if (hit != null)
        {
            //Player player = hit.collider.GetComponent<Player>();
            //if (player != null)
            //    player.Die();
        }

        rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        hit = Physics2D.Raycast((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x + offset), visionDistance, LayerMask.NameToLayer("Player"));
        Debug.DrawRay((Vector2)this.transform.position + offset, rotation * (Vector2.right * transform.localScale.x * visionDistance ), Color.yellow);

        if (hit != null)
        {
            //Player player = hit.collider.GetComponent<Player>();
            //if (player != null)
            //    player.Die();
        }
    }
}
