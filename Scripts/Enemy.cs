using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy object's RigidBody2D reference
    private Rigidbody2D body;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float upwardBoost;
    private Vector2 movementDirection;
    public int pointValue;

    void Awake()
    {
        // Get reference to the rigidbody on the attach enemy component.
        body = GetComponent<Rigidbody2D>();
        //movementDirection = Vector2.right;
        movementDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
    }

    // Move enemy in a direction based on a speed
    public void Move(Vector2 direction)
    {
        // Add movement speed to x velocity and keep y velocity the same, which has already been calculated by the physics engine.
        body.velocity = new Vector2(direction.x * moveSpeed, body.velocity.y);
    }

    public float getUpwardBoost()
    {
        return upwardBoost;
    }

    // If we collide with something, that has a collider and is not a trigger.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        movementDirection *= -1f;
    }

    // If camera sees enemy for the first time, assign movement.
    private void OnBecameVisible()
    {
        if (movementDirection == Vector2.zero)
        {
            movementDirection = Vector2.right;
        }
    }
}
