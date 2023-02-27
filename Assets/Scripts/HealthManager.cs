using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This class is responsible for managing the player's health
public class HealthManager : MonoBehaviour
{
    private TMP_Text healthText;
    private Slider healthSlider;
    private Animator heartAnimator;
    private int healthVal;

    private void Start() {
        // Set the default health to 100
        healthVal = 100;

        // Get the health text UI component
        healthText = GameObject.Find("Health").GetComponent<TMP_Text>();
        // Get the health bar component
        healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        // The health animation component
        heartAnimator = GameObject.Find("Heart").GetComponent<Animator>();
    }

    // Sets the player's health
    public void SetHealth(int amount) {
        // Update the player's health
        healthVal = amount;
        // Play the animation
        heartAnimator.Play("HealthUpAnim", 0, 0.4f);
    }

    // Returns the player's current health
    public int GetHealth() {
        return healthVal;
    }

    // Reduces the player's health
    public void ReduceHealth(int amountToReduce) {
        // Update the player's health
        healthVal -= amountToReduce;
        // Play the animation
        heartAnimator.Play("ShakeHeart", 0, 0.4f);
    }


    private void FixedUpdate() {
        // Update the health text in the UI
        healthText.text = $"{healthVal}/100";
        // Update the health bar value in the UI
        healthSlider.value = healthVal;
    }
}
