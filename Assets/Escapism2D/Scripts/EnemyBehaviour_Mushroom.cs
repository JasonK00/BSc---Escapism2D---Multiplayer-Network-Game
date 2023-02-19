using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_Mushroom : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float runningSpeed = 2f;

    private enum MovementState { idle, running, hit }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if(IsFacingRight())
        {
            rb.velocity = new Vector3(moveSpeed, 0f);
        }else
        {
            rb.velocity = new Vector3(-moveSpeed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector3(-(Mathf.Sign(rb.velocity.x)),transform.localScale.y);
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if(IsFacingRight())
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(!IsFacingRight())
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        //IF statement for 'running'

/*
private void UpdateAnimationUpdate()
{
    MovementState state;

    if(dirX >0f)
    {
        state = MovementState.running;
        sprite.flipX = false;
    }
    else if(dirX < 0f)
    {
        state = MovementState.running;
        sprite.flipX = true;
    }

    if(OnCollisionEnter2D())
    {
        state = MovementState.hit;
    }
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player")); 
                    
    }

    private bool IsGrounded()
{
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
}*/
    }
}
