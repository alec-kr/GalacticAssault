using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The DestroyInSeconds class destroys an attached object after a specified time 
public class DestroyInSeconds : MonoBehaviour
{
    // How long to wait before destroying object
    [SerializeField] private float secondsToDestroy;

    void Start()
    {
        // Destroy the object after the specified time
        Destroy(gameObject, secondsToDestroy);    
    }
}
