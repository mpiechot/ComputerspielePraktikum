using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;



public enum ScenesToLoad
{

    ReneTunnel,
    HotelLobby2
}

public class LevelManager : MonoBehaviour
{
    
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public int currentTunnelNumber;
    public static LevelManager instance = null;

    public GameObject player;
    public GameObject[] tunnelExitArray;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (tunnelExitArray.Length == 0)
        {
            tunnelExitArray = GameObject.FindGameObjectsWithTag("TunnelExit");
        }
    }


    IEnumerator LoadAsyncronously(ScenesToLoad scene)
    {
        
        scenesToLoad.Add(SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive));
        

        while (!scenesToLoad[scenesToLoad.Count - 1].isDone)
        {
           
            yield return null;
        }

        tunnelExitArray = GameObject.FindGameObjectsWithTag("TunnelExit");

        for (int i = 0; i < tunnelExitArray.Length; i++)
        {
            
            if (tunnelExitArray[i].GetComponent<TunnelExitScript>().tunnelNumber == currentTunnelNumber)
            {
                player.transform.rotation = tunnelExitArray[i].transform.rotation;
                gameObject.transform.rotation = tunnelExitArray[i].transform.rotation;
                //GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = tunnelExitArray[i].transform.rotation;

                player.transform.position = tunnelExitArray[i].transform.position;
                gameObject.transform.position = tunnelExitArray[i].transform.position;
                //GameObject.FindGameObjectWithTag("MainCamera").transform.position = tunnelExitArray[i].transform.position;

            }
        }

    }



    public void LoadScene(ScenesToLoad scene, int passedTunnelNumber)
    {
        currentTunnelNumber = passedTunnelNumber;

        StartCoroutine(LoadAsyncronously(scene));
        //SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive);
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


}
