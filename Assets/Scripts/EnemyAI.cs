using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for controlling the enemy's movement
public class EnemyAI : MonoBehaviour
{
    // Player location
    private Transform player;
    // 
    private Vector3 playerPos;
    // Enemy ship position
    private Vector3 enemyPos;
    // The speed of the enemy ship
    private float speed;
    // Distance between enemy and player ship
    private float dist;
    private Rigidbody2D _rigidbody;
    private int closeThreshold = 5;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("PlayerShip").transform;
        // The speed of each enemy ship will be randomly determined on spawn
        speed = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        // If the player does not exist
        if(player == null)
            return;

        _rigidbody = GetComponent<Rigidbody2D>();

        playerPos = player.position; 
        enemyPos = transform.position;
        dist = Vector3.Distance(playerPos, enemyPos);

        // If the enemy is not close to the player, move closer
        if(dist >= closeThreshold)
            _rigidbody.AddForce(this.transform.up * this.speed);

        // Else, move away from the player a bit
        else
            _rigidbody.AddForce(this.transform.up * -this.speed);


        // Calculate the direction of the player's ship
        Vector2 direction = playerPos - enemyPos;

        // Rotate towards the direction of the player
        transform.rotation = Quaternion.RotateTowards(
                                 transform.rotation,
                                 Quaternion.FromToRotation(Vector2.up, direction),
                                 100.0f * Time.deltaTime
                             );
    }

}
