using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAwayOnContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            this.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
