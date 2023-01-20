using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    public GameObject textPrefab;
    public int lives = 3;
    // This function will be called when a bullet hits the ship
    public void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void takeDamage() {
        if (gameObject != null) {
            if (lives > 1) {
                hitEffect.Play();
                lives -= 1;
            }
            else
                death();
            
            Instantiate(textPrefab, transform.position, Quaternion.identity);
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore(2);
        }
    }
}
