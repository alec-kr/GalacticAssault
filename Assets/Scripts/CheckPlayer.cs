using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is responsible for checking if the player still exists
public class CheckPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Find the player ship
        player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        // If the player's ship is not found, load the game over scene
        if (player == null)
            StartCoroutine(LoadLevelAfterDelay(0.5f));
    }

    // Loads the Game Over scene after a specified delay
    IEnumerator LoadLevelAfterDelay(float delay)
     {
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene("GameOverScene");
     }
}
