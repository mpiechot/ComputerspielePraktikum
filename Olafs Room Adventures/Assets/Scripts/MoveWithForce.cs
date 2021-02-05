using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithForce : MonoBehaviour
{
    public Transform destination; // used to calculate the movement vector

    public void ActivateConstantForce() 
    {
        Vector3 direction = new Vector3(destination.position.x - this.transform.position.x, 
                                        destination.position.y - this.transform.position.y, 
                                        destination.position.z - this.transform.position.z);
        this.GetComponent<Rigidbody>().AddForce(direction * 2.0f, ForceMode.Impulse);
    } 

}
