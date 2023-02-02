using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private AudioSource shootEffect;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject flasher;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1.0f, 1.0f);
    }

    void Shoot() {
        // Spawn bullets
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject orangeFlasher = Instantiate(flasher, transform.position, transform.rotation) as GameObject;
        orangeFlasher.transform.parent = gameObject.transform;
        shootEffect.Play();
    }
}
