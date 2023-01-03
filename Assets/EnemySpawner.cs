using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    private GameObject player;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("PlayerShip");
        InvokeRepeating("RandomSpawn", 2.0f, 5.0f);
    }

    void RandomSpawn() {
        if (player == null)
            return;

        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
    }
}
