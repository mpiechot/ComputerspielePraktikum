using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
    	SceneManager.LoadScene("Philipp", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        Universal.load_game = true;
        SceneManager.LoadScene("Level4.0", LoadSceneMode.Single);
    }

    public void ExitGame ()
    {
    	Debug.Log("QUIT");
    	Application.Quit();
    }
}
