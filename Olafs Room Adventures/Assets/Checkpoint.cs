using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> CheckpointReachedEvent;
    private bool isReached = false;
    [SerializeField]
    private int checkpointID = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CheckpointReachedEvent?.Invoke(checkpointID);
            isReached = true;
            //Destroy(gameObject);
        }
    }
}
