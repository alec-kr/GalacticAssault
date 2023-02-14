using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private GameObject settingsPanel;
    private GameObject instructionsPanel;

    // Load the game scene
    public void playGame() {
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

    // Activate the instruction panel
    public void showInstructions() {
        instructionsPanel = GameObject.Find("Panel").transform.Find("InstructionsPanel").gameObject;
        instructionsPanel.SetActive(true);
    }

    public void hideInstructions() {
        instructionsPanel = GameObject.Find("Panel").transform.Find("InstructionsPanel").gameObject;
        instructionsPanel.GetComponent<Animator>().Play("SlideRight");
    }

    public void exitGame() {
        Application.Quit();
    }
}
