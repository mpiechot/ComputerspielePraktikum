using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject opmenu, self;

    public void PlayGame ()
    {
    	SceneManager.LoadScene("Philipp", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        Universal.load_game = true;
        SceneManager.LoadScene(SaveSystem.loadSceneName(), LoadSceneMode.Single);
    }

    public void Options()
    {
        self.SetActive(false);
        opmenu.SetActive(true);
    }

    public void ExitGame ()
    {
    	Debug.Log("QUIT");
    	Application.Quit();
    }
}
