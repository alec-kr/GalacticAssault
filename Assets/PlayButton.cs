using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // public int gameScene;
    public void playGame() {
        // SceneManager.LoadScene(gameScene);
        SceneManager.LoadScene("GameScene");
    }
}
