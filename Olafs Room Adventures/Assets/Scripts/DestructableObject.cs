using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    [Space(45)]
    [Header("Rigidbodys automatically to them")]
    [Header("Child-Gameobjects. This Script will add")]
    [Header("Note: Dont use a Rigidbody-Component on")]

    [SerializeField]
    [Range(0,20)]
    private float maxImpulseValue;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude >= maxImpulseValue)
        {
            Break();
        }
    }

    private void Break()
    {
        Destroy(gameObject.GetComponent<Collider>());
        Destroy(gameObject.GetComponent<Rigidbody>());
        foreach(Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = true;
            if(collider.gameObject.GetComponent<Rigidbody>() == null)
            {
                collider.gameObject.AddComponent(typeof(Rigidbody));
            }
        }
    }
}
