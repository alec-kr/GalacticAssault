using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    private TMP_Text healthText;
    private Slider healthSlider;
    private Animator heartAnimator;
    private int healthVal;

    private void Start() {
        healthVal = 100;

        healthText = GameObject.Find("Health").GetComponent<TMP_Text>();
        healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        heartAnimator = GameObject.Find("Heart").GetComponent<Animator>();
    }

    public void SetHealth(int amount) {
        healthVal = amount;
    }

    public int GetHealth() {
        return healthVal;
    }

    public void ReduceHealth(int amountToReduce) {
        healthVal -= amountToReduce;
        heartAnimator.Play("ShakeHeart", 0, 0.4f);
    }

    private void FixedUpdate() {
        healthText.text = $"{healthVal}/100";
        healthSlider.value = healthVal;
    }
}
