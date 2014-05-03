using UnityEngine;
using System.Collections;

public class EnemyNoWrap : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Enemy en = col.gameObject.GetComponent<Enemy>();
            if (en != null)
            {
                en.noWarp = true;
            }
        }

    }
}
