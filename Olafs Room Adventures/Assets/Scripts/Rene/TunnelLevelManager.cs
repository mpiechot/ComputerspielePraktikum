using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using Cinemachine;


public enum ScenesToLoad
{

    ReneTunnel,
    HotelLobby2
}

public class TunnelLevelManager : MonoBehaviour
{

    public CinemachineFreeLook cinemachine;
    public Camera cam;
    public Transform head;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public int currentTunnelNumber;
    public static TunnelLevelManager instance = null;

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
                //place tunnel on exit with right number
                
                player.transform.rotation = tunnelExitArray[i].transform.rotation;
                gameObject.transform.rotation = tunnelExitArray[i].transform.rotation;
                
                Transform oldTransform = player.transform;
                player.transform.position = tunnelExitArray[i].transform.position;
                gameObject.transform.position = tunnelExitArray[i].transform.position;

                
                
                //rotate camera same as tunnel
                cinemachine.ForceCameraPosition(player.transform.position, tunnelExitArray[i].transform.rotation);
                


                
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
