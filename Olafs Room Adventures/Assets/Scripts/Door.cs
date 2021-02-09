using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool openState = false;
    private Animator anim;

    private bool changeState = true;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeState)
        {
            if (openState)
            {
                anim.ResetTrigger("Close");
                anim.SetTrigger("Open");
            }
            else
            {
                anim.ResetTrigger("Open");
                anim.SetTrigger("Close");

            }
            changeState = false;
        }
    }
    public void Open()
    {
        openState = true;
        changeState = true;
    }
    public void Close()
    {
        openState = false;
        changeState = true;
    }

}
