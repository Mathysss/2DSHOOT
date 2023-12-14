using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreset : MonoBehaviour
{
    public Settings settings;
    private float BasicMusicValue = 0.2f;
    private float BasicSFXValue = 0.2f;

    void Start()
    {
        // Apply preset properties to the player
        if (PlayerPrefs.GetFloat("musicVolume") != settings.MusicVolume && PlayerPrefs.GetFloat("sfxVolume") != settings.SFXVolume)
        { 
            PlayerPrefs.SetFloat("musicVolume", BasicMusicValue);
            PlayerPrefs.SetFloat("sfxVolume", BasicSFXValue);            
         
        }
    }
}
