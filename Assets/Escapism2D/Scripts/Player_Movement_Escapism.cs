using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Escapism : MonoBehaviour
{
private Rigidbody2D rb;
private BoxCollider2D coll;
private SpriteRenderer sprite;
private Animator anim;
private int doubleJ;

private float dirX = 0f;
[SerializeField] private float movementSpeed = 7f;
[SerializeField] private float jumpForce = 14f;
[SerializeField] private bool doubleJump = false;      //is doubleJump enable?
[SerializeField] private LayerMask jumpableGround;

private enum MovementState { idle, running, jumping, doublejumping, falling }

[SerializeField] private AudioSource jumpSoundEffect;

private void Start()
{
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    sprite = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    doubleJ = 2;
}

private void Update()
{
    dirX = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
        jumpSoundEffect.Play();
        GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpForce);
        doubleJ = 1;
    }

    UpdateAnimationUpdate();

    if (Input.GetButtonDown("Jump") && !IsGrounded() && doubleJump == true)
    {
        if(doubleJ > 0)
        {
            jumpSoundEffect.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJ = 0;
        }
    }

    UpdateAnimationUpdate();

/*
    if ((Input.GetButtonDown("Jump") && !IsGrounded) && (maxJumps != 0))      //Checks if the jumpsLeft is more than 0, if yes - make the jump!
    {
        jumpSoundEffect.Play();
        GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpForce);
        maxJumps--;            //Decrement jumpsLeft every time the player jumps
    }

    UpdateAnimationUpdate();
    */
}
    
private void UpdateAnimationUpdate()
{
    MovementState state;

    if (dirX > 0f)
    {
        state = MovementState.running;
        sprite.flipX = false;
    }
    else if (dirX < 0f)
    {
        state = MovementState.running;
        sprite.flipX = true;
    }
    else
    {
        state = MovementState.idle;
    }

    if (rb.velocity.y > .1f && doubleJ == 1)
    {       
        state = MovementState.jumping;    
    }

   else if (rb.velocity.y > .1f && doubleJ == 0)
    {
        state = MovementState.doublejumping;
    }


    else if (rb.velocity.y < -.1f)
    {
        state = MovementState.falling;

    }

    anim.SetInteger("state", (int)state);
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.layer == jumpableGround)      //Checks if the player has landed on a jumpable ground
    {
        doubleJ = 2;            //Resets the number of jumps to 2 when the player lands on jumpable ground
    }
}

private bool IsGrounded()
{
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
}
}