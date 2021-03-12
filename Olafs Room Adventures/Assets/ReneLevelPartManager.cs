using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReneLevelPartManager : MonoBehaviour
{
    
    AsyncOperation levelToLoad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator LoadAsyncronously(string scene)
    {
        levelToLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        

        while (!levelToLoad.isDone)
        {
             yield return null;
        }
        
    }

    public void loadPart(string scene)
    {

            StartCoroutine(LoadAsyncronously(scene));
  
    }
}
