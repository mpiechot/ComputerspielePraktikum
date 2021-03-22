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
    [Range(1,20)]
    private float maxImpulseValue = 15;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude >= maxImpulseValue)
        {
            Break();
        }
    }

    private void Break()
    {
        if(gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
        foreach (Collider collider in GetComponents<Collider>())
        {
            Destroy(collider);
        }
        Destroy(gameObject.GetComponent<Rigidbody>());
        Collider[] children = GetComponentsInChildren<Collider>();
        foreach (Collider collider in children)
        {
            collider.enabled = true;
            if(collider.gameObject.GetComponent<Rigidbody>() == null)
            {
                collider.gameObject.AddComponent(typeof(Rigidbody));
            }
            else
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
            }
            //DestructableObject destObj = collider.gameObject.AddComponent<DestructableObject>();
            //destObj.maxImpulseValue = Mathf.Clamp(maxImpulseValue - 3, 1, 20);
        }
        Destroy(this);
    }
}
