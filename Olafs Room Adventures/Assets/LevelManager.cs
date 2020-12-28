using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesToLoad
{
    ReneTunnel,
    HotelLobby
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
            Debug.Log("Loading Scene: " + scene.ToString());
            yield return null;
        }

        tunnelExitArray = GameObject.FindGameObjectsWithTag("TunnelExit");

        for (int i = 0; i < tunnelExitArray.Length; i++)
        {
            Debug.Log("TunnelExitNumber:" + tunnelExitArray[i].GetComponent<TunnelExitScript>().tunnelNumber);
            if (tunnelExitArray[i].GetComponent<TunnelExitScript>().tunnelNumber == currentTunnelNumber)
            {
                player.transform.position = tunnelExitArray[i].transform.position;
                gameObject.transform.position = tunnelExitArray[i].transform.position - new Vector3(3,0,0);
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
