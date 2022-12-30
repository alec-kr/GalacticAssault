using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private AudioSource shootEffect;
    public GameObject bulletPrefab;
    public Transform enemyLocation;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1.0f, 1.0f);
    }

    void Shoot() {
        // Spawn bullets
        Instantiate(bulletPrefab, enemyLocation.position, enemyLocation.rotation);
        shootEffect.Play();
    }
}
