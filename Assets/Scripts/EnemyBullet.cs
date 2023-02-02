using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float velocity = 20f;
    private Rigidbody2D rb;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "PlayerShip") {
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            col.gameObject.GetComponent<PlayerShip>().takeDamage();
            Destroy(gameObject);
        }
    }
}