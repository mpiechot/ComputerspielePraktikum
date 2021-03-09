using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSwitch : MonoBehaviour
{
    public bool Active { get; private set; }
    public UnityEvent<InteractableSwitch> SwitchStateChangedEvent;

    private Animator anim;

    private void Start()
    {
        Active = false;
        anim = GetComponent<Animator>();
    }
    public void UseSwitch()
    {
        Switch();
        SwitchStateChangedEvent?.Invoke(this);
    }
    public void TurnOff()
    {
        if (Active)
        {
            Switch();
        }
    }

    public void Switch()
    {
        Debug.Log("Switch!");
        Active = !Active;
        anim.SetBool("SwitchOn", Active);
    }
}
