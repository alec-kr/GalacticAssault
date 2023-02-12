using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name.StartsWith("EnemyShip")) {
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            col.gameObject.GetComponent<EnemyShip>().takeDamage();
            Destroy(gameObject);
        }
    }
}
