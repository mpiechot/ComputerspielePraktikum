using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithForce : MonoBehaviour
{
    public Transform destination; // used to calculate the movement vector
    public float Strength = 2.0f;

    public void ActivateConstantForce() 
    {
        Vector3 direction = destination.position - transform.position;

        this.GetComponentInChildren<Rigidbody>().AddForce(direction * Strength, ForceMode.Impulse);
    }
    public void ActivateConstantForceAway()
    {
        Vector3 direction = (destination.position - transform.position) * -1;

        this.GetComponentInChildren<Rigidbody>().AddForce(direction * Strength, ForceMode.Impulse);
    }

    public void IncreaseStrength()
    {
        Strength *= 2;
    }
}
