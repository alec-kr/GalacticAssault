using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreText;
    private int scoreVal = 0;

    public void AddScore(int amountToAdd) {
        scoreVal += amountToAdd;
    }

    private void FixedUpdate() {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        scoreText.text = $"Score: {scoreVal}";
    }
}
