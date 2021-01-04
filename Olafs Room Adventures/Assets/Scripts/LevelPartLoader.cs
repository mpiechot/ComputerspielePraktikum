using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPartLoader : MonoBehaviour
{

    private bool isLoaded;
    private bool shouldLoad;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.sceneCount < 0)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == "ReneTunnel")
                {
                    isLoaded = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TriggerCheck();
    }

    void LoadScene()
    { 
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync("ReneTunnel", LoadSceneMode.Additive);
            isLoaded = true;
        }
    }

    void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync("ReneTunnel");
            isLoaded = false;
        }
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
