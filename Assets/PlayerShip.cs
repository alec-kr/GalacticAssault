using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    public int lives = 3;
    // Start is called before the first frame update

    public void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the gameObject
            // Destroy(gameObject);
        }
    }

    public void takeDamage() {
        if (gameObject != null) {
            if (lives > 1) 
                lives -= 1;
            // else
                // death();
        }
    }
}
