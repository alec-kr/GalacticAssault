using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFixed : MonoBehaviour
{
    private float startX;
    private float startY;
    private Vector3 startLoc;
    private Vector3 currLoc;
    GameObject player;
    void Start() {
        player = GameObject.Find("PlayerShip");

        if (player == null)
            return;

        startX = this.transform.position.x;
        startY = this.transform.position.y;
        startLoc = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        currLoc = player.transform.position;
        this.transform.position = new Vector3(startX-(currLoc.x-startLoc.x), startY-(currLoc.y-startLoc.y));
    }
}
