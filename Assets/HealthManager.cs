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
    private int healthVal = 100;

    private void Start() {
        healthText = GameObject.Find("Health").GetComponent<TMP_Text>();
        healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        heartAnimator = GameObject.Find("Heart").GetComponent<Animator>();
    }

    public void AddHealth(int amountToAdd) {
        healthVal += amountToAdd;
    }

    public void reduceHealth(int amountToReduce) {
        healthVal -= amountToReduce;
        heartAnimator.Play("ShakeHeart", 0, 0.4f);
    }

    private void FixedUpdate() {
        healthText.text = $"{healthVal}/100";
        healthSlider.value = healthVal;
    }
}
