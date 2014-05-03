using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int PlayerId;

    private Animator anim;

	public bool dead = false;

	Vector2 startPos;

	void Awake() {
		startPos = transform.position;
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

		collider2D.enabled = false;
		rigidbody2D.gravityScale = 0f;
		rigidbody2D.velocity = Vector2.zero;
		transform.Translate(Vector3.up);

        anim.SetTrigger("Die");

		Invoke("Respawn", 2f);
    }

	void Respawn() {
		dead = false;
		anim.SetTrigger("Respawn");
		collider2D.enabled = true;
		rigidbody2D.gravityScale = 1f;
		transform.position = startPos;
	}
}
