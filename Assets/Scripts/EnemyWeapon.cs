using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The EnemyWeapon class is responsible for shooting bullets from the enemy's weapon
public class EnemyWeapon : MonoBehaviour
{
    // shooting sound effect
    [SerializeField] private AudioSource shootEffect;
    // Prefab of the bullet that will be shot
    [SerializeField] private GameObject bulletPrefab;
    // Muzzle flash prefab
    [SerializeField] private GameObject flasher;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1.0f, 1.0f);
    }

    // Fires a bullet from the enemy's weapon
    void Shoot() {
        // Spawn bullet at weapon position and rotation
        Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Instantiate the muzzle flash
        GameObject orangeFlasher = Instantiate(flasher, transform.position, transform.rotation) as GameObject;
        // Attach the muzzle flash as a child of the GameObject, so that it doesn't just float in space
        orangeFlasher.transform.parent = gameObject.transform;

        // Play the shooting sound effect
        shootEffect.Play();
    }
}
