using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Enemy[] enemies;
    [SerializeField]
    private Gem[] gems;

    public void spawnEnemy(GameObject placedPlatform, float maxWidth)
    {
        // Generate a random number between 0 and enemies length for enemy generation.
        int randomNumber = Random.Range(0, enemies.Length);

        // Create new position for enemy to spawn at (slightly above a platform).
        Vector3 enemyPos = new Vector3(Random.Range(-maxWidth, maxWidth), placedPlatform.transform.position.y + 0.6f, placedPlatform.transform.position.z);

        // Instantiate one of the enemies
        Enemy enemyInstance = Instantiate(enemies[randomNumber], enemyPos, Quaternion.identity);
    }

    public void spawnGem(GameObject placedPlatform, float maxWidth)
    {
        // Generate a random number between 0 and gems length for gem generation.
        int randomNumber = Random.Range(0, gems.Length);

        // Create new position for enemy to spawn at (slightly above a platform).
        Vector3 gemPos = new Vector3(Random.Range(-maxWidth, maxWidth), placedPlatform.transform.position.y + 0.6f, placedPlatform.transform.position.z);

        // Instantiate one of the enemies
        Gem gemInstace = Instantiate(gems[randomNumber], gemPos, Quaternion.identity);
    }
}
