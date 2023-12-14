using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool isPaused = false;
    public bool enabledSettings = false;
    public Canvas UI;
    public Canvas PauseMenu;
    public Canvas Settings;
    public GameObject PauseMenuPostProcessing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false )
        {
            isPaused = true;
            PauseMenu.gameObject.SetActive(true);
            PauseMenuPostProcessing.gameObject.SetActive(true);
            UI.gameObject.SetActive(false);
            Time.timeScale = 0;
            AudioManager.instance.SlowDownMusic();

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && enabledSettings == false   )
        {
            isPaused = false;
            PauseMenu.gameObject.SetActive(false);
            PauseMenuPostProcessing.gameObject.SetActive(false);
            UI.gameObject.SetActive(true);
            Time.timeScale = 1;
            AudioManager.instance.SpeedUpMusic();
        }
    }
    public void ResumePauseMenu()
    {
        isPaused = false;
        PauseMenu.gameObject.SetActive(false);
        PauseMenuPostProcessing.gameObject.SetActive(false);
        UI.gameObject.SetActive(true);
        Time.timeScale = 1;
        AudioManager.instance.SpeedUpMusic();
    }
    public void SettingsEnable()
    {
        enabledSettings = true;
        PauseMenu.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }
    public void SettingsDisable()
    {
        enabledSettings = false;
        Settings.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }
}
