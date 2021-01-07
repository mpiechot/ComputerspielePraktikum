using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> checkpoints;
    public void OnCheckPointReached(int cpNum)
    {
        if(cpNum < 0 || cpNum >= checkpoints.Count)
        {
            Debug.LogError("Assign a valid Checkpoint Number to all Checkpoints or insert the new Checkpoint to the LevelManager!");
        }

        checkpoints[cpNum].SetActive(true);
    }
}
