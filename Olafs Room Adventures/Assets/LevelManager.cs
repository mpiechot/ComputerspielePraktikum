using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<UnityEvent> checkpoints;
    [SerializeField]
    private List<CheckpointStartPosition> startPositions;
    [SerializeField]
    private int currentCheckpoint = 0;
    private void Start()
    {
        PlayerPrefs.SetInt("CurrentCheckpoint", 2);
        currentCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
        if(currentCheckpoint > 0)
        {
            Universal.load_game = true;
            for (int i = 0; i < currentCheckpoint; i++)
            {
                if(i < checkpoints.Count)
                {
                    checkpoints[i].Invoke();
                }
            }
            GetComponent<GameSaveController>().Load(startPositions[currentCheckpoint-1]);
        }
    }

    public void OnCheckPointReached()
    {
        currentCheckpoint++;
        PlayerPrefs.SetInt("CurrentCheckpoint", currentCheckpoint);
        //if(cpNum < 0 || cpNum >= checkpoints.Count)
        //{
        //    Debug.LogError("Assign a valid Checkpoint Number to all Checkpoints or insert the new Checkpoint to the LevelManager!");
        //}

        //checkpoints[cpNum].SetActive(true);
    }
}
