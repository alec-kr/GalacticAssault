using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private GameObject settingsPanel;
    private GameObject instructionsPanel;

    // public int gameScene;
    public void playGame() {
        // SceneManager.LoadScene(gameScene);
        SceneManager.LoadScene("GameScene");
    }

    public void mainMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public void showSettings() {
        settingsPanel = GameObject.Find("Panel").transform.Find("SettingsPanel").gameObject;
        settingsPanel.SetActive(true);
    }

    public void hideSettings() {
        settingsPanel = GameObject.Find("Panel").transform.Find("SettingsPanel").gameObject;
        settingsPanel.GetComponent<Animator>().Play("SlideOut");
    }

    public void showInstructions() {
        instructionsPanel = GameObject.Find("Panel").transform.Find("InstructionsPanel").gameObject;
        instructionsPanel.SetActive(true);
    }

    public void hideInstructions() {
        instructionsPanel = GameObject.Find("Panel").transform.Find("InstructionsPanel").gameObject;
        instructionsPanel.GetComponent<Animator>().Play("SlideRight");
    }
}
