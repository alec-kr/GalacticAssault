using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class controls the events attached to the menu buttons
public class MenuButton : MonoBehaviour
{
    private GameObject settingsPanel;
    private GameObject instructionsPanel;

    // Loads the game scene
    public void playGame() {
        SceneManager.LoadScene("GameScene");
    }

    // Loads the main menu scene
    public void mainMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    // Shows the settings panel
    public void showSettings() {
        // Find the settings panel object
        settingsPanel = GameObject.Find("Panel").transform.Find("SettingsPanel").gameObject;
        // Activate the settings panel
        settingsPanel.SetActive(true);
    }

    public void hideSettings() {
        // Find the settings panel object
        settingsPanel = GameObject.Find("Panel").transform.Find("SettingsPanel").gameObject;
        // Slide the panel off the screen
        settingsPanel.GetComponent<Animator>().Play("SlideOut");
    }

    // Activate the instruction panel
    public void showInstructions() {
        // Find the instructions panel object
        instructionsPanel = GameObject.Find("Panel").transform.Find("InstructionsPanel").gameObject;
        // Activate the panel
        instructionsPanel.SetActive(true);
    }

    public void hideInstructions() {
        // Find the instructions panel object
        instructionsPanel = GameObject.Find("Panel").transform.Find("InstructionsPanel").gameObject;
        // Slide the panel off the screen
        instructionsPanel.GetComponent<Animator>().Play("SlideRight");
    }

    // Exits the game
    public void exitGame() {
        Application.Quit();
    }
}
