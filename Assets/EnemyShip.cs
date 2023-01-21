using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private GameObject textPrefab;
    private int health = 30;
    // This function will be called when a bullet hits the ship
    private void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            health = 0;
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void takeDamage() {
        int randScore = Random.Range(1, 11);

        if (gameObject != null) {
            GameObject scoreParent = Instantiate(textPrefab, transform.position, Quaternion.identity);
            scoreParent.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = $"+{randScore}";

            if (health > randScore) {
                hitEffect.Play();
                health -= randScore;
            }

            else {
                randScore = health;
                death();
            }

            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore(randScore);
        }
    }
}
