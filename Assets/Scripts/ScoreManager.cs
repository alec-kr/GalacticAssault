using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This class manages the game score
public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreText;
    private int scoreVal;

    private void Start() {
        // Set the score to 0
        scoreVal = 0;
        // Find the score text UI object
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Add a specific amount to the current score
    public void AddScore(int amountToAdd) {
        scoreVal += amountToAdd;
    }

    // Returns the current score
    public int GetScore() {
        return scoreVal; 
    }

    // Update the score text with the current score value
    private void FixedUpdate() {
        // Set the score UI text
        scoreText.text = $"Score: {scoreVal}";

        // If the current score is greater than the high score
        if (scoreVal > PlayerPrefs.GetInt("highScore")) {
            // Update the highscore
            PlayerPrefs.SetInt("highScore", scoreVal);
        }
    }
}
