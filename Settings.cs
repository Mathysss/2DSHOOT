using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SFXSlider;

    public float MusicVolume = 1f;
    public float SFXVolume = 1f;

    public void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat("musicVolume");
        SFXVolume = PlayerPrefs.GetFloat("sfxVolume");
        AudioManager.instance.musicSource.volume = MusicVolume;
        AudioManager.instance.sfxSorce.volume = SFXVolume;
        MusicSlider.value = MusicVolume;
        SFXSlider.value = SFXVolume;

    }

    public void Update()
    {
        AudioManager.instance.musicSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("musicVolume", MusicVolume);
        AudioManager.instance.sfxSorce.volume = SFXVolume;
        PlayerPrefs.SetFloat("sfxVolume", SFXVolume);

        
    }

    public void MusicVolumeChange(float volume)
    {
        MusicVolume = volume;
        
        
        
    }

    public void SFXVolumeChange(float volume)
    {
        SFXVolume = volume;
        
       
    }
    public void BackMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
