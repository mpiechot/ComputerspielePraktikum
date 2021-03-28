using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float force_factor = 10;
    public void applyRandomForceToAllRigidbodies(){
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddForce(Random.Range(-force_factor,force_factor),Random.Range(-force_factor,force_factor),Random.Range(-force_factor,force_factor));
        }
    }

}

