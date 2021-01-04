using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimator;

    void OnTriggerEnter (Collider other) 
    {
        if (other.tag == "Player")
        {
            doorAnimator.SetBool("open", true);
        }
    }
}
