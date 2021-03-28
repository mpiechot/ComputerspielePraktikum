using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause_menu_panel;
    public GameObject options_menu_panel;
    public GameObject buttons;

    bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (!paused)
            {
                showPause();
            }
        }
    }

    public void Resume(){
        pause_menu_panel.SetActive(false);
        options_menu_panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void showPause(){
        Time.timeScale = 0f;
        pause_menu_panel.SetActive(true);
    }

    public void showOptions()
    {
        buttons.SetActive(false);
        options_menu_panel.SetActive(true);
    }

    public void backyopause()
    {
        buttons.SetActive(true);
        options_menu_panel.SetActive(false);
    }

    public void backToMain()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
