using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int PlayerId;

    private Animator anim;

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
        anim.SetTrigger("Die");
    }
}
