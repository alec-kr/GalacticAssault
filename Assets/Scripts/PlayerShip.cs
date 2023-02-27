using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is responsible for managing the player's ship
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private AudioSource powerUpSound;
    [SerializeField] private GameObject textPrefab;
    private HealthManager healthMgr;

    private void Start() {
        // Get the health manager and set health to 100
        healthMgr = GameObject.Find("GameHUD").GetComponent<HealthManager>();
        healthMgr.SetHealth(100);
    }

    // Destory the player's ship
    private void death() {
        // Check if the ship still exists
        if (gameObject != null) {
            // Set the health to 0
            healthMgr.SetHealth(0);
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the player's ship
            Destroy(gameObject);
        }
    }

    // Inflict damage on the player's ship
    public void takeDamage() {
        // Generate a random damage value from 1-10
        int randDamage = Random.Range(1, 11);
        
        // Chcek if the player ship still exists
        if (gameObject != null) {
            // Show the floating damage score
            GameObject damageParent = Instantiate(textPrefab, transform.position, Quaternion.identity);
            damageParent.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = $"-{randDamage}";

            // Play the hit audio effect
            hitEffect.Play();

            // If the player's health is more than the damage
            if (healthMgr.GetHealth() > randDamage)
                // Reduce the health
                healthMgr.ReduceHealth(randDamage);

            // If the damage is more than the player's health
            else
                // Destroy the player's ship
                death();
        }

    }

    // Called when a collision is detected
    private void OnTriggerEnter2D(Collider2D col) {
        // If the player ship collides with an extra life powerup
        if (col.name.StartsWith("ExtraLife")) {
            // Destroy the powerup and play the sound effect
            Destroy(col.gameObject);
            powerUpSound.Play();

            // Set the player health to 100
            healthMgr.SetHealth(100);

        }
    }
}
