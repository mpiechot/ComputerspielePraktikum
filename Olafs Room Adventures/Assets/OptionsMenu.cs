using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    public GameObject pause_menu_panel;
    public GameObject options_menu_panel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ShowMenu();
        }
    }


    public void changeVolume(){

    }

    public void ShowMenu(){
        Debug.Log("Show Menu");
        options_menu_panel.SetActive(false);
        pause_menu_panel.SetActive(true);
    }
}
