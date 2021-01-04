using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class TunnelScript : MonoBehaviour
{
    private bool isLoaded;
    private bool shouldLoad;

    

    public ScenesToLoad SceneToLoad;
    public int tunnelNumber;
    // Start is called before the first frame update
    void Start()
    {
        

        if (SceneManager.sceneCount < 0)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == SceneToLoad.ToString())
                {
                    isLoaded = true;
                }
            }
        }
    }

    void Update()
    {
        TriggerCheck();
    }

    void TriggerCheck()
    {
        if (shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }


    void LoadScene()
    {
        if (!isLoaded)
        {
            TunnelLevelManager.instance.LoadScene(SceneToLoad, tunnelNumber);
            isLoaded = true;
        }
    }

    void UnLoadScene()
    {
        if (isLoaded)
        {
           // LevelManager.instance.UnLoadScene(SceneToLoad);
            //isLoaded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }


}
