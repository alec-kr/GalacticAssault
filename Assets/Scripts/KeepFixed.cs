using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The KeepFixed class is responsible for keeping objects 
// fixed in space, relative to the player's location
public class KeepFixed : MonoBehaviour
{
    private float startX;
    private float startY;
    private Vector3 startLoc;
    private Vector3 currLoc;
    // The player's ship
    GameObject player;
    void Start() {
        player = GameObject.Find("PlayerShip");

        // If the player's ship doesn't exist, do nothing
        if (player == null)
            return;

        // Get the starting coordinates
        startX = this.transform.position.x;
        startY = this.transform.position.y;
        startLoc = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player's ship doesn't exist, do nothing
        if (player == null)
            return;

        // Get the player's current location
        currLoc = player.transform.position;

        // Update the position of the object, relative to the player location
        this.transform.position = new Vector3(
                                            startX-(currLoc.x-startLoc.x), 
                                            startY-(currLoc.y-startLoc.y)
                                );
    }
}
