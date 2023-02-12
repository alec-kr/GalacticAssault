using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The EnemySpawner class is responsible for randomly spawning enemies at various locations
public class EnemySpawner : MonoBehaviour
{
    // An array containing all enemy ships
    public GameObject[] enemyPrefabs;
    // An array containing all spawn points
    public GameObject[] spawnPoints;
    // The player ship
    private GameObject player;
    private float rate = 2.0f;

    // Update is called once per frame
    void Start()
    {
        // Find the player's ship
        player = GameObject.Find("PlayerShip");
        InvokeRepeating("RandomSpawn", 2.0f, rate);
    }

    void FixedUpdate() {
        // Get the current score
        int score = GameObject.Find("GameHUD").GetComponent<ScoreManager>().GetScore();

        // If the current spawn rate does not match the score, update the spawn rate
        if (score < 50 && rate != 2.0f) {
            // Cancel the current InvokeRepeating()
            CancelInvoke("RandomSpawn");
            rate = 2.0f; // Update the spawn rate
            // Start a new InvokeRepeating with the new spawn rate
            InvokeRepeating("RandomSpawn", 1.0f, rate);
        }

        else if (score >= 50 && score < 100 && rate != 1.8f) {
            // Cancel the current InvokeRepeating()
            CancelInvoke("RandomSpawn");
            rate = 1.8f; // Update the spawn rate
            // Start a new InvokeRepeating with the new spawn rate
            InvokeRepeating("RandomSpawn", 1.0f, rate);
        }

        else if (score >= 100 && score < 200 && rate != 1.5f) {
            // Cancel the current InvokeRepeating()
            CancelInvoke("RandomSpawn");
            rate = 1.5f; // Update the spawn rate
            // Start a new InvokeRepeating with the new spawn rate
            InvokeRepeating("RandomSpawn", 1.0f, rate);
        }

        else if (score >= 200 && score < 300 && rate != 1.2f) {
            // Cancel the current InvokeRepeating()
            CancelInvoke("RandomSpawn");
            rate = 1.2f; // Update the spawn rate
            // Start a new InvokeRepeating() with the new spawn rate
            InvokeRepeating("RandomSpawn", 1.0f, rate);
        }

        else if (score >= 300 && rate != 1.0f) {
            // Cancel the current InvokeRepeating()
            CancelInvoke("RandomSpawn");
            rate = 1.0f; // Update the spawn rate
            // Start a new InvokeRepeating() with the new spawn rate
            InvokeRepeating("RandomSpawn", 1.0f, rate);
        }
    }

    // This function will randomly spawn an enemy at a spawn point
    void RandomSpawn() {
        // If the player doesn't exist, don't spawn anything
        if (player == null)
            return;

        // Choose a random index from the enemy ship and spawn point arrays
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        // Instantiate the randomly chosen enemy ship at the random spawn point
        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
    }
}
