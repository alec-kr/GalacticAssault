using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This class is responsible for showing the high score
public class showHighScore : MonoBehaviour
{
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the highscore text component
        scoreText = gameObject.GetComponent<TMP_Text>();
        // Update the component to show the high score
        scoreText.text = $"High Score\n{PlayerPrefs.GetInt("highScore")}";
    }
}
