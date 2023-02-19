using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Waypoint_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private int currentWaypointIndex = 0;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float runningSpeed = 6f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {running,hit}

    private void Update()
    {
       if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
{
    currentWaypointIndex++;
    if (currentWaypointIndex >= waypoints.Length)
    {
        currentWaypointIndex = 0;
    }

    if (waypoints[currentWaypointIndex].transform.position.x < transform.position.x)
    {
        GetComponent<SpriteRenderer>().flipX = true;
    }
    else if (waypoints[currentWaypointIndex].transform.position.x > transform.position.x)
    {
        GetComponent<SpriteRenderer>().flipX = false;
    }
}

transform.position = Vector2.MoveTowards(transform.position,waypoints[currentWaypointIndex].transform.position, Time.deltaTime *speed);
}


    private bool IsGrounded()
{
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector3.down, .1f, jumpableGround);
}

}
