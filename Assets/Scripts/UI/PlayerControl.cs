using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;			// For determining which way the player is currently facing.
    [HideInInspector]
    public bool isJumping = false;				// Condition for whether the player should jump.

    [HideInInspector]
    public bool lockControls = false;


    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
    public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
    public float jumpForce = 1000f;			// Amount of force added when the player jumps.
    public AudioClip[] taunts;				// Array of clips for when the player taunts.
    public float tauntProbability = 50f;	// Chance of a taunt happening.
    public float tauntDelay = 1f;			// Delay for when the taunt should happen.
    public Knife Knife;
    public Score scoreCounter;


    private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
    public Transform groundCheck;			// A position marking where to check if the player is grounded.
    private bool grounded = false;			// Whether or not the player is grounded.
    private Animator anim;					// Reference to the player's animator component.

    private string _playerId;

    private Player player;

    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
        anim = transform.Find("body").GetComponent<Animator>();
        _playerId = this.GetComponent<Player>().PlayerId.ToString();
        player = GetComponent<Player>();
    }

    public bool GroundCheck()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void Update()
    {
        if (player.dead) return;

        // jumping
        grounded = GroundCheck();
        if (grounded)
        {
            anim.SetBool("Jump", false);

            if (Input.GetButtonDown("Jump" + _playerId))
            {
                isJumping = true;
            }
        }

        if (lockControls)
        {
            ResetAnimationValues(); return;
        }

        // knifing
        if (Input.GetButtonDown("Action" + _playerId))
        {
            // always play animation
            anim.SetTrigger("Knife");

            // kill when hitting player that is not dead
            if (Knife.KnifeTarget != null && !Knife.KnifeTarget.dead)
            {
                scoreCounter.AddScore(Knife.KnifeTarget.scoreValue);
                Knife.KnifeTarget.Kill();
            }
        }
    }


    void FixedUpdate()
    {
        if (player.dead) return;
        if (lockControls) return;

        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal" + _playerId);

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * rigidbody2D.velocity.x < maxSpeed)
            // ... add a force to the player.
            rigidbody2D.AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // If the player should jump...
        if (isJumping)
        {
            // Set the Jump animator trigger parameter.
            anim.SetBool("Jump", true);

            // Play a random jump audio clip.
            int i = Random.Range(0, jumpClips.Length);
            AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            // Add a vertical force to the player.
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            isJumping = false;
        }

    }


    void Flip()
    {
        if (player.dead) return;

        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public IEnumerator Taunt()
    {
        // Check the random chance of taunting.
        float tauntChance = Random.Range(0f, 100f);
        if (tauntChance > tauntProbability)
        {
            // Wait for tauntDelay number of seconds.
            yield return new WaitForSeconds(tauntDelay);

            // If there is no clip currently playing.
            if (!audio.isPlaying)
            {
                // Choose a random, but different taunt.
                tauntIndex = TauntRandom();

                // Play the new taunt.
                audio.clip = taunts[tauntIndex];
                audio.Play();
            }
        }
    }

    void ResetAnimationValues()
    {
        anim.SetFloat("Speed", 0);
    }

    int TauntRandom()
    {
        // Choose a random index of the taunts array.
        int i = Random.Range(0, taunts.Length);

        // If it's the same as the previous taunt...
        if (i == tauntIndex)
            // ... try another random taunt.
            return TauntRandom();
        else
            // Otherwise return this index.
            return i;
    }
}
