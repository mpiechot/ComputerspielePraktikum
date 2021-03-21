using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneTriggerTopView : MonoBehaviour
{
    private ReneMoveToTopView switchCam;
    private bool switched = false;
    
    private PlayerGravityMovement oldMovement;
    
    private PlayerMovement newMovement;
    // Start is called before the first frame update
    void Start()
    {
        switchCam = FindObjectOfType<ReneMoveToTopView>();
        oldMovement = FindObjectOfType<PlayerGravityMovement>();
        newMovement = FindObjectOfType<PlayerMovement>();
        Debug.Log(oldMovement.gameObject.name);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !switched)
        {
            switchCam.SwitchCam();
            newMovement.enabled = false;
            oldMovement.enabled = true;
            switched = true;
        }
    }
}
