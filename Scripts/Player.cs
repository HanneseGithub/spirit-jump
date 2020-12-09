using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int distance;
	public int maxDistance;

	[SerializeField]
	private Sound sounds;
	[SerializeField]
	private float movementSpeed = 10f;

	private float movement = 0f;
	private Rigidbody2D rb;
	private Game game;
	private Vector3 dir = Vector3.zero;

	private void Awake()
	{
		// Make references automatically.
		game = FindObjectOfType<Game>();
		rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame.
    void Update()
	{
		// MOBILE MOVEMENT START
		if (Input.acceleration.x < 0.07 && Input.acceleration.x > 0)
        {
			dir.x = 0;
		} else
        {
			dir.x = Input.acceleration.x;
		}

		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		// Make it move 10 meters per second instead of 10 meters per frame...
		dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * movementSpeed);
        // MOBILE MOVEMENT END

        // Save computer input
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        // Save user's distance.
        distance = Mathf.FloorToInt(transform.position.y);
		
		// Update maxDistance, if player reaches new maximum height.
		if (maxDistance < distance )
        {
			maxDistance = distance;
		}
	}

	void FixedUpdate()
	{
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// If enemy's body collides with player, end the game.
		if (collision.gameObject.CompareTag("Enemy"))
		{
			sounds.gameover.Play();
			game.EndGame();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// If enemy's head is triggered by player, delete the enemy.
		if (collision.gameObject.CompareTag("Enemy"))
        {
			// Play jumping sound if player hits the enemy.
			sounds.destroying.Play();

			Destroy(collision.gameObject);

			// We can't change the velocity straight away, must create new vector.
			Vector2 velocity = rb.velocity;
			velocity.y = collision.gameObject.GetComponent<Enemy>().getUpwardBoost();

			// Assign the rigidbody the updated vector.
			rb.velocity = velocity;

			// Add score for killing the enemy.
			game.addCollectiblesScore(collision.gameObject.GetComponent<Enemy>().pointValue);
		}

        if (collision.gameObject.CompareTag("Gem"))
        {
            // Play jumping sound if player hits the gem.
            sounds.gem.Play();
        }
    }
}
