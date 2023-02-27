using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the player bullet behaviour
public class PlayerBullet : MonoBehaviour
{
    private float velocity;
    private Rigidbody2D rb;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Set the bullet velocity
        velocity = 20f;

        // Get the bullet rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Update the velocity of the bullet
        rb.velocity = transform.up * velocity;
    }

    // Called when a collision is detected
    private void OnTriggerEnter2D(Collider2D col) {
        // If the bullet has collided with an enemy ship
        if (col.name.StartsWith("EnemyShip")) {
            // Play the hit effect
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            // Inflict damage on the enemy ship
            col.gameObject.GetComponent<EnemyShip>().takeDamage();
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
