using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadOrAlive : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject[] platformPrefabs;
    [SerializeField]
    private float maxWidth = 2.15f;
    [SerializeField]
    private float minY = 0.8f;
    [SerializeField]
    private float maxY = 3f;
    [SerializeField]
    Spawner spawnables;

    private Game game;
    private int fadingCounter = 0;
    private bool fading = false;
    private int startingPlatforms = 30;

    // Create a new position for the platforms to spawn.
    private Vector3 spawnPosition = new Vector3();

    private GameObject lastPlatform;

    AudioSource gameover;

    private void Awake()
    {
        // Calculate screen's width from screenpoint to world point (bottom right corner)
        Vector3 tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 10f));

        // Assign the x value as maxWidth (0.7 off for half the platform)
        maxWidth = tempPos.x - 0.7f;

        // Make reference to game automatically, without having to assign it yourself.
        game = FindObjectOfType<Game>();

        // Game over sound
        gameover = GetComponent<AudioSource>();
    }

    // Use this for initialization
    private void Start()
    {
        // Start the game starting coroutine - 3s delay & then spawn platforms
        StartCoroutine(startGameWithCountdown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it's the player, load the end game function. Instead of destroying the player alone, let the scene loader destroy the whole scene.
        if (collision.gameObject.CompareTag("Player"))
        {

            // Play sound if player dies
            gameover.Play();

            game.EndGame();
            return;
        }

        // If it wasn't the player, destroy the object
        Destroy(collision.gameObject);

        // Instantiate new platform after every platform destroy

        // X-axis.
        spawnPosition.x = Random.Range(-maxWidth, maxWidth);
        // Y-axis. Generate platform random distance from the last platform's position.
        spawnPosition.y = lastPlatform.transform.position.y + Random.Range(minY, maxY);

        // New instance of the platform prefab.
        // 1% chance for fading. Spawn 10 fadings in a row.
        // 5% chance for spring to spawn.
        // Else spawn normal platform.
        float platformRandom = Random.value;

        // Check whether fading minigame is still active.
        if (fading == true)
        {
            // Check whether 10 platforms have been spawned.
            if (fadingCounter < 10)
            {
                // Create a fading platform and add +1 to counter,
                lastPlatform = Instantiate(platformPrefabs[2], spawnPosition, Quaternion.identity);
                fadingCounter++;
            } else
            {
                // If 10 platforms are full, end the minigame, reset fading and spawn a normal platform.
                lastPlatform = Instantiate(platformPrefabs[0], spawnPosition, Quaternion.identity);
                fading = false;
                fadingCounter = 0;
            }
        } else
        {
            // If it's not fading, check which platform to spawn.
            if (platformRandom <= 0.02)
            {
                // If it's under 2%, spawn a fading platform and enable fading.
                lastPlatform = Instantiate(platformPrefabs[2], spawnPosition, Quaternion.identity);
                fading = true;
                fadingCounter++;
            } else if (platformRandom > 0.02 && platformRandom <= 0.08)
            {
                // 6% chance to spawn a spring platform.
                lastPlatform = Instantiate(platformPrefabs[1], spawnPosition, Quaternion.identity);
            } else
            {
                // Spawn normal platform.
                lastPlatform = Instantiate(platformPrefabs[0], spawnPosition, Quaternion.identity);
            }
        }

        // Each time a new platform is instatiated, there is a 15% chance for an enemy to spawn.
        if (Random.value <= 0.15)
        {
            spawnables.spawnEnemy(lastPlatform, maxWidth);
        }

        // Each time a new platform is instatiated, there is 7% chance for a gem to spawn
        if (Random.value <= 0.07)
        {
            spawnables.spawnGem(lastPlatform, maxWidth);
        }
        
    }

    IEnumerator startGameWithCountdown()
    {
        // Make the game wait 3 seconds before spawning the platforms
        yield return new WaitForSeconds(3f);

        // Spawn starting platform numbers of platforms at the start
        for (int i = 0; i < startingPlatforms; i++)
        {
            // X-axis
            spawnPosition.y += Random.Range(minY, maxY);
            // Y-axis.
            spawnPosition.x = Random.Range(-maxWidth, maxWidth);

            // If 3 platforms have been spawned, there is 15% chance for spring.
            if (Random.value <= 0.15 && i > 3)
            {
                lastPlatform = Instantiate(platformPrefabs[1], spawnPosition, Quaternion.identity);
            } else
            {
                lastPlatform = Instantiate(platformPrefabs[0], spawnPosition, Quaternion.identity);
            }

            // Each time a new platform is instatiated, there is a chance 10% for an enemy to spawn. Avoid spawning enemy at spawn.
            if (Random.value <= 0.1 && i > 3)
            {
                spawnables.spawnEnemy(lastPlatform, maxWidth);
            }

            // Each time a new platform is instatiated, there is 5% chance for a gem to spawn. Avoid spawning it at spawn.
            if (Random.value <= 0.05 && i > 3)
            {
                spawnables.spawnGem(lastPlatform, maxWidth);
            }
        }
    }
}
