using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {


	public float WarpFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		// If the player hits the trigger...
		if (col.gameObject.tag != "NoWarp") 
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                Enemy en = col.gameObject.GetComponent<Enemy>();
                if (en != null)
                {
                    if (en.noWarp != true)
                    {
                        Vector3 newPos = col.gameObject.transform.position;
                        newPos = new Vector3(-(newPos.x * WarpFactor), newPos.y, newPos.z);
                        col.gameObject.transform.position = newPos;
                    }
                }
            }
            else
            {
                Vector3 newPos = col.gameObject.transform.position;
                newPos = new Vector3(-(newPos.x * WarpFactor), newPos.y, newPos.z);
                col.gameObject.transform.position = newPos;
            }

			
		}
	}
}
