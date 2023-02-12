using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreText;
    private int scoreVal;

    private void Start() {
        scoreVal = 0;
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
        scoreText.text = $"Score: {scoreVal}";

        if (scoreVal > PlayerPrefs.GetInt("myScore")) {
            PlayerPrefs.SetInt("myScore", scoreVal);
        }
    }
}
