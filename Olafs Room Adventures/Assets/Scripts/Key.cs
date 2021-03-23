using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField]
    private UnityEvent KeyCollectedEvent;

    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CollectKey();
        }
    }

    public void CollectKey()
    {
        KeyCollectedEvent?.Invoke();
        Destroy(gameObject);
    }
}
