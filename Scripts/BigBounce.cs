using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBounce : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 20f;
    AudioSource jumpsound;

    private void Start()
    {
        jumpsound = GetComponent<AudioSource>();
    }

    // When object collides with another object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Relative velocity between two colliding objects.
        // In this case, it's checking the moving objects velocity (because the other one is always 0).
        if (collision.relativeVelocity.y <= 0f)
        {
            if (collision.collider.CompareTag("Player"))
            {
                // Play jumping sound if player hits the platform.
                jumpsound.Play();
            }

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            // Let's check if the colliding object has a rigidbody 2d. If it doesn't it's not the player.

            if (rb != null)
            {
                // We can't change the velocity straight away, because Unity wants us to change the whole velocity not just a component of it.
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;


                // Assign the rigidbody whole new vector.
                rb.velocity = velocity;
            }
        }
    }
}
