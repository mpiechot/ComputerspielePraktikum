using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public enum Scene { 
        ReneTunnel,
    }

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public void StartLevel() 
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync(Scene.ReneTunnel.ToString()));
    }

    public void LoadLevel(Scene scene)
    {
        StartCoroutine(LoadAsyncronously(scene));
    }

    IEnumerator LoadAsyncronously(Scene scene) 
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync(scene.ToString() , LoadSceneMode.Additive ));

        while (!scenesToLoad[scenesToLoad.Count - 1].isDone )
        {
            Debug.Log("Loading Scene: " + scene.ToString());
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadLevel(Scene.ReneTunnel);
    }
}
