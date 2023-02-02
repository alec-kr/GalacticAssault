using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject flasher;
    [SerializeField] private AudioSource shootEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot() {
        // Spawn bullets
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject blueFlasher = Instantiate(flasher, transform.position, transform.rotation) as GameObject;
        blueFlasher.transform.parent = gameObject.transform;
        shootEffect.Play();
    }

}