using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    // This function will be called when a bullet hits the ship
    public void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            // Destroy the gameObject
            Destroy(gameObject);
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
