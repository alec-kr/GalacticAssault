using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStarfield : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;
        GameObject player = GameObject.Find("PlayerShip");
        
        offset.x = player.transform.position.x/transform.localScale.x/2.0f;
        offset.y = player.transform.position.y/transform.localScale.y/2.0f;

        mat.mainTextureOffset = offset;
    }
}
