using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerLocation;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        // Spawn bullets
        Instantiate(bulletPrefab, playerLocation.position, playerLocation.rotation);
    }

}