using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerShip");        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {
            StartCoroutine(LoadLevelAfterDelay(0.5f));
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
     {
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene("GameOverScene");
     }
}
