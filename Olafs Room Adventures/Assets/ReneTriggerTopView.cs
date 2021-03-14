using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneTriggerTopView : MonoBehaviour
{
    private ReneMoveToTopView switchCam;
    private bool switched = false;
    // Start is called before the first frame update
    void Start()
    {
        switchCam = FindObjectOfType<ReneMoveToTopView>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !switched)
        {
            switchCam.SwitchCam();
            switched = true;
        }
    }
}
