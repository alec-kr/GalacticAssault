using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    public int lives = 3;
    // This function will be called when a bullet hits the ship
    public void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the gameObject
            Destroy(gameObject);
        }
    }

    public void takeDamage() {
        if (gameObject != null) {
            hitEffect.Play();
            if (lives > 1)
                lives -= 1;
            else
                death();
        }
    }

    // If the ship leaves the screen, destroy the object
    private void OnBecameInvisible()
    {
        // Check if the gameObject exists
        if (gameObject != null)
        {    
            // Destroy the gameObject
            Destroy(gameObject);
        }
    }
}
