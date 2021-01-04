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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Impulse Mag: " + collision.impulse.magnitude);
        Debug.Log("Relative Velocity: " + collision.relativeVelocity);
        Debug.Log("mass: " + collision.rigidbody.mass);
    }
}
