using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    public int lives = 3;
    public GameObject textPrefab;

    public void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            // Start the explosion effect
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the gameObject
            Destroy(gameObject);
        }
    }

    public void takeDamage() {
        if (gameObject != null) {
            hitEffect.Play();
            if (lives > 1) 
                lives -= 1;
            else
                death();

            // Move this above if statement
            int randDamage = Random.Range(1, 11);

            GameObject damageParent = Instantiate(textPrefab, transform.position, Quaternion.identity);
            damageParent.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = $"-{randDamage}";
        }
    }
}
