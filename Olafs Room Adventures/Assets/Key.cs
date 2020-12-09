using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField]
    private UnityEvent KeyCollectedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            KeyCollectedEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
