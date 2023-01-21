using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    private int health = 100;
    [SerializeField] private GameObject textPrefab;

    private void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            health = 0;
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the gameObject
            Destroy(gameObject);
        }
    }

    public void takeDamage() {
        int randDamage = Random.Range(1, 11);
        
        if (gameObject != null) {

            GameObject damageParent = Instantiate(textPrefab, transform.position, Quaternion.identity);
            damageParent.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = $"-{randDamage}";

            hitEffect.Play();

            if (health > randDamage) {
                health -= randDamage;
                GameObject.Find("GameHUD").GetComponent<HealthManager>().reduceHealth(randDamage);
            }

            else
                death();
        }

    }
}
