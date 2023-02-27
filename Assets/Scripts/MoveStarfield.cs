using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for moving the game's background
public class MoveStarfield : MonoBehaviour
{
    private GameObject sfield; // The starfield
    private GameObject bdrop; // The galaxy backdrop

    private void Start() {
        // Initialize the values
        sfield = GameObject.Find("Starfield");
        bdrop = GameObject.Find("Backdrop");
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player ship object
        GameObject player = GameObject.Find("PlayerShip");
        
        // Return if the player does not exist
        if (player == null)
            return;
 
        // Get the mesh renderer and material of both backgrounds
        MeshRenderer sfield_mr = sfield.GetComponent<MeshRenderer>();
        Material sfield_mat = sfield_mr.material;

        MeshRenderer bdrop_mr = bdrop.GetComponent<MeshRenderer>();;
        Material bdrop_mat = bdrop_mr.material;
        

        // Get main texture offset of both backgrounds
        Vector2 sfield_offset = sfield_mat.mainTextureOffset;
        Vector2 bdrop_offset = bdrop_mat.mainTextureOffset;

        // Update the offset of the starfield positively relative to the player's location
        sfield_offset.x = player.transform.position.x/sfield.transform.localScale.x/2.0f;
        sfield_offset.y = player.transform.position.y/sfield.transform.localScale.y/2.0f;

        // Update the offset of the backdrop negatively relative to the player's location
        bdrop_offset.x = -player.transform.position.x/bdrop.transform.localScale.x/2.0f;
        bdrop_offset.y = -player.transform.position.y/bdrop.transform.localScale.y/2.0f;


        // Update the main texture offset with the new values
        sfield_mat.mainTextureOffset = sfield_offset;
        bdrop_mat.mainTextureOffset = bdrop_offset;
    }
}
