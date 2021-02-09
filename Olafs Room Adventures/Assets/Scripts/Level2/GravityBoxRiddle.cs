using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravityBoxRiddle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent RiddleFinishedEvent;

    private void OnTriggerEnter(Collider other)
    {
        RiddleFinishedEvent?.Invoke();
    }
}
