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

    // Update is called once per frame
    void Start()
    {
        // Find the player's ship
        player = GameObject.Find("PlayerShip");
        InvokeRepeating("RandomSpawn", 2.0f, 5.0f);
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
