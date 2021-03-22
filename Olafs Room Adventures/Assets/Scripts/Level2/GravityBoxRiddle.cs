using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravityBoxRiddle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent RiddleFinishedEvent;
    private bool alreadyFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyFinished)
        {
            RiddleFinishedEvent?.Invoke();
            alreadyFinished = true;
        }
    }
}
