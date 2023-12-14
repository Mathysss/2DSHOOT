using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool pauseMenuEnabled = false;
    public Canvas pauseMenu;
    
    public Canvas UI;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && pauseMenuEnabled == false)
        {
            EnablePauseMenu();
        }

        if (Input.GetKey(KeyCode.Escape) && pauseMenuEnabled == true)
        {
            DisablePauseMenu();
        }


    }
    void EnablePauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        UI.gameObject.SetActive(false);
    }
    void DisablePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        UI.gameObject.SetActive(true);
    }
}
