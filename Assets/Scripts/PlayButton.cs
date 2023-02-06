using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private GameObject settingsPanel;

    private void Start() {
        settingsPanel = GameObject.Find("Panel").transform.Find("SettingsPanel").gameObject;
    }
    // public int gameScene;
    public void playGame() {
        // SceneManager.LoadScene(gameScene);
        SceneManager.LoadScene("GameScene");
    }

    public void showSettings() {
        settingsPanel.SetActive(true);
    }

    public void hideSettings() {
        settingsPanel.SetActive(false);
    }
}
