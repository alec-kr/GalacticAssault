using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStarfield : MonoBehaviour
{
    private GameObject sfield;
    private GameObject bdrop;

    private void Start() {
        sfield = GameObject.Find("Starfield");
        bdrop = GameObject.Find("Backdrop");
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("PlayerShip");
        
        if (player == null)
            return;
 
        MeshRenderer sfield_mr = sfield.GetComponent<MeshRenderer>();
        Material sfield_mat = sfield_mr.material;

        MeshRenderer bdrop_mr = bdrop.GetComponent<MeshRenderer>();;
        Material bdrop_mat = bdrop_mr.material;
        

        Vector2 sfield_offset = sfield_mat.mainTextureOffset;
        Vector2 bdrop_offset = bdrop_mat.mainTextureOffset;
        
        sfield_offset.x = player.transform.position.x/sfield.transform.localScale.x/2.0f;
        sfield_offset.y = player.transform.position.y/sfield.transform.localScale.y/2.0f;

        bdrop_offset.x = -player.transform.position.x/bdrop.transform.localScale.x/2.0f;
        bdrop_offset.y = -player.transform.position.y/bdrop.transform.localScale.y/2.0f;

        sfield_mat.mainTextureOffset = sfield_offset;
        bdrop_mat.mainTextureOffset = bdrop_offset;
    }
}
