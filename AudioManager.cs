using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] musicSounds, sfxSounds;

    public AudioSource musicSource, sfxSorce;
    public float musicPitch = 0.5f;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        PlayMusic("MainTheme");
    }

    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");

        }
        else
        {
            musicSource.clip = s.Clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        } else
        {
            sfxSorce.clip = s.Clip;
            sfxSorce.PlayOneShot(s.Clip);
        }



    }
    public void SlowDownMusic()
    {
        musicSource.pitch = musicPitch;
    }
    public void SpeedUpMusic()
    {
        musicSource.pitch = 1;
    }
}
