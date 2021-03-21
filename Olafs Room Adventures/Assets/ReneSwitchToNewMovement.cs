using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneSwitchToNewMovement : MonoBehaviour
{
    private ReneOldMovementInverted oldMovement;
    private bool switched = false;
    private PlayerMovement newMovement;
    // Start is called before the first frame update
    void Start()
    {
        oldMovement = FindObjectOfType<ReneOldMovementInverted>();
        newMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!switched && other.gameObject.tag == "Player")
        {
            oldMovement.enabled = false;
            newMovement.enabled = true;
            
            switched = true;
        }
        
    }
}
