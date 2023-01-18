using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private Vector3 playerPos;
    private Vector3 enemyPos;
    private float speed;
    private float dist;
    private int closeThreshold = 5;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("PlayerShip").transform;
        speed = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        if(player == null) {
            return;
        }

        _rigidbody = GetComponent<Rigidbody2D>();

        playerPos = player.position; 
        enemyPos = transform.position;
        dist = Vector3.Distance(playerPos, enemyPos);

        if(dist >= closeThreshold) {
            _rigidbody.AddForce(this.transform.up * this.speed);
        }

        else {
            _rigidbody.AddForce(this.transform.up * -this.speed);
        }

        Vector2 direction = playerPos - enemyPos;
        transform.rotation = Quaternion.RotateTowards(
                                 transform.rotation,
                                 Quaternion.FromToRotation(Vector2.up, direction),
                                 100.0f * Time.deltaTime
                             );
    }

}
