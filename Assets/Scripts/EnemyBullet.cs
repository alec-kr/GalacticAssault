using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The EnemyBullet class controls the behaviour of the bullets used by enemies
public class EnemyBullet : MonoBehaviour
{
    // Bullet speed
    public float velocity = 20f;
    private Rigidbody2D rb;
    // The animation that is played when the bullet hits the player
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Get the RigidBody2D component of the bullet
        rb = GetComponent<Rigidbody2D>();
        // Set the velocity of the bullet
        rb.velocity = transform.up * velocity;
    }

    // Runs when the bullet collision is detected
    private void OnTriggerEnter2D(Collider2D col) {
        // If the bullet collided with the player's ship 
        if (col.name == "PlayerShip") {
            // Instantiate the hit animation
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            // Inflict damage on the player's ship
            col.gameObject.GetComponent<PlayerShip>().takeDamage();
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
