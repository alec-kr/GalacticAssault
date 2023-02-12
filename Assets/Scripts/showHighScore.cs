using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showHighScore : MonoBehaviour
{
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
        scoreText.text = $"High Score\n{PlayerPrefs.GetInt("myScore")}";
    }
}
