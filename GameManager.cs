using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager gamemanager;

    public Canvas PauseMenu;
    public Canvas UI;
    public GameObject PauseMenuPostProcessing;

    public float MusicVolume;
    public float SFXVolume;

    


    public void Awake()
    {

        if (gamemanager == null)
        {
            gamemanager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.SpeedUpMusic();
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("MainTheme");
    }

    public void ResetScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    public void MainMenuPlay()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    public void MainMenuQuit()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void LevelSelect2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void LevelSelect3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void LevelSelect4()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void LevelSelect5()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
    public void LevelSelect6()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
    public void LevelSelect7()
    {
        SceneManager.LoadScene(8);
        Time.timeScale = 1;
    }
    public void LevelSelect8()
    {
        SceneManager.LoadScene(9);
        Time.timeScale = 1;
    }
    public void LevelSelect9()
    {
        SceneManager.LoadScene(10);
        Time.timeScale = 1;
    }
    public void LevelSelect10()
    {
        SceneManager.LoadScene(11);
        Time.timeScale = 1;
    }
    public void LevelSelect11()
    {
        SceneManager.LoadScene(12);
        Time.timeScale = 1;
    }
    public void LevelSelect12()
    {
        SceneManager.LoadScene(13);
        Time.timeScale = 1;
    }
    public void LevelSelectBack()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }





    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Music volume:" + MusicVolume);
            Debug.Log("SFX volume:" + SFXVolume);





        }
    }
}
