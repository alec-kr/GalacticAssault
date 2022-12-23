using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    private void Update()
    {
        if(player == null) {
            Debug.Log("No Player!!!");
            return;
        }

        playerPos = player.transform.position;

        float distance = Vector2.Distance(playerPos, transform.position);
        
        transform.position = Vector2.MoveTowards(this.transform.position, playerPos, 3 * Time.deltaTime);
        Vector2 direction = playerPos - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
