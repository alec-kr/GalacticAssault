using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private GameObject spawnHealthAnim;
    private ScoreManager scoreMgr;
    private int health = 30;
    public GameObject explosionAnim;

    private void Start() {
        scoreMgr = GameObject.Find("GameHUD").GetComponent<ScoreManager>();
    }

    // This function will be called when a bullet hits the ship
    private void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            health = 0;
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Instantiate(explosionAnim, transform.position, Quaternion.identity);

            if(Random.Range(1, 4) == 3)
                SpawnHealth();

            Destroy(gameObject);
        }
    }

    // Inflict damage on the enemy ship
    public void takeDamage() {
        // Generate a random damage value from 1 to 10
        int randScore = Random.Range(1, 11);

        if (gameObject != null) {
            // Set up the floating score text
            GameObject scoreParent = Instantiate(textPrefab, transform.position, Quaternion.identity);
            scoreParent.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = $"+{randScore}";

            // If enemy has enough health
            if (health > randScore) {
                // Play the hit sound effect, and reduce the health
                hitEffect.Play();
                health -= randScore;
            }

            // Else, destroy the enemy ship
            else {
                death();
            }

            // Update the player score
            scoreMgr.AddScore(randScore);
        }
    }

    private void SpawnHealth() {
        Instantiate(spawnHealthAnim, transform.position, transform.rotation);
        Instantiate(heartPrefab, transform.position, transform.rotation);
     }
}
