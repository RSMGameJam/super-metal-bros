using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int PlayerId;
	public bool dead = false;

    private Animator anim;

	private PlayerControl playerControl;

	Vector2 startPos;

	void Awake() {
		startPos = transform.position;
		playerControl = GetComponent<PlayerControl>();
	}

	// Use this for initialization
	void Start () 
    {
        anim = transform.Find("body").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void Die()
    {
		if(dead) return;
		
		dead = true;

		anim.SetTrigger("Die");
		transform.Find("body").Translate(Vector3.up);

		Invoke("Respawn", 2f);
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		// Wait for blood to fall onto the ground
		if (dead)
		{
			if (playerControl.GroundCheck())
			{
				rigidbody2D.isKinematic = true;
				collider2D.enabled = false;
			}
		}
	}

	void Respawn() {
		dead = false;

		anim.SetTrigger("Respawn");

		// reposition body
		transform.Find("body").Translate(-Vector3.up);

		// reenable physics on the player carcass
		rigidbody2D.isKinematic = false;
		collider2D.enabled = true;
	}
}