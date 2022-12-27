using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private float speed;
    public Vector3 pos;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("PlayerShip");
        speed = Random.Range(3.0f, 5.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        if(player == null) {
            Debug.Log("No Player!!!");
            return;
        }

        playerPos = player.transform.position;        

        transform.position = Vector2.MoveTowards(this.transform.position, playerPos, speed * Time.deltaTime);
        Vector2 direction = playerPos - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

}
