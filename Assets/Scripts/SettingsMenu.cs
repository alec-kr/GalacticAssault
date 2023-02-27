using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// This class is responsible for handling the 
// audio sliders in the settings menu
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    // Set the music volume to the value of the slider
    public void SetMusicVolume(float volume) {
        musicMixer.SetFloat("MusicVolume", volume);
    }

    // Set the SFX volume to the value of the slider
    public void SetSFXVolume(float volume) {
        sfxMixer.SetFloat("SfxVolume", volume);
    }
}
