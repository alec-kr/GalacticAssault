using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private GameObject textPrefab;
    private HealthManager healthMgr;

    private void Start() {
        healthMgr = GameObject.Find("GameHUD").GetComponent<HealthManager>();
        healthMgr.SetHealth(100);
    }


    private void death() {
        // Check if the gameObject still exists
        if (gameObject != null) {
            healthMgr.SetHealth(0);
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

            if (healthMgr.GetHealth() > randDamage) {
                healthMgr.ReduceHealth(randDamage);
            }

            else
                death();
        }

    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name.StartsWith("ExtraLife")) {
            Destroy(col.gameObject);
            healthMgr.SetHealth(100);
        }
    }
}
