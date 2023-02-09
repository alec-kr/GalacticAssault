using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Cannon class is responsible for shooting bullets from the player's weapon
public class Cannon : MonoBehaviour
{
    // The prefab of the bullet that will be shot
    [SerializeField] private GameObject bulletPrefab;
    // prefab of the muzzle flash
    [SerializeField] private GameObject flasher;
    // shooting sound effect
    [SerializeField] private AudioSource shootEffect;
    public AudioClip shoot;
    // Update is called once per frame
    void Update()
    {
        // If the "Z" key is pressed, shoot the bullet
        if(Input.GetButtonDown("Fire1"))
            Shoot();
    }

    // Fires a bullet from the player's weapon
    void Shoot() {
        // Spawn bullet at weapon position and rotation
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        
        // Instantiate the muzzle flash
        GameObject blueFlasher = Instantiate(flasher, transform.position, transform.rotation) as GameObject;
        // Attach the muzzle flash as a child of the GameObject, so that it doesn't just float in space
        blueFlasher.transform.parent = gameObject.transform;
        
        // Play the shoot sound effect
        shootEffect.PlayOneShot(shoot, 0.7f);
    }

}