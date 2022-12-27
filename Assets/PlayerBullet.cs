using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float velocity = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * velocity;    
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name.StartsWith("EnemyShip")) {
            col.gameObject.GetComponent<EnemyShip>().takeDamage();
            // col.gameObject.GetComponent<EnemyShip>().death();
            Debug.Log("Collision with ship");
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        if (gameObject != null)
        {    
            // Do something  
            Destroy(gameObject);
        }
    }
}
