using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchSequenceRiddle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent RiddleFailedEvent;
    [SerializeField]
    private UnityEvent RiddleFinishedEvent;
    private int currentIndex = 0;

    [SerializeField]
    private InteractableSwitch[] switchOrder;


    public void OnSwitchStateChanged(InteractableSwitch interactableSwitch)
    {
        if(switchOrder[currentIndex] != interactableSwitch)
        {
            Reset();
        }
        if(!interactableSwitch.Active)
        {
            Reset();
        }
        if((currentIndex+1) == switchOrder.Length)
        {
            RiddleFinishedEvent?.Invoke();
        }
        else
        {
            currentIndex++;
        }
    }

    private void Reset()
    {
        RiddleFailedEvent?.Invoke();
        foreach(InteractableSwitch interSwitch in switchOrder)
        {
            interSwitch.TurnOff();
        }
        currentIndex = 0;
    }
}
