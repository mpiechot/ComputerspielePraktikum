using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableDoor : MonoBehaviour
{
    [SerializeField]
    private int keysNeeded;
    private bool isOpen;

    private GameManager gm;
    public UnityEvent DoorUnlockedEvent;

    private void Start()
    {
        isOpen = false;
        gm = GameManager.Instance;
    }
    public void UseDoor()
    {
        if(gm.PlayerHasKeys && keysNeeded > 0)
        {
            gm.OnUseKey();
            keysNeeded--;
        }
        if(keysNeeded == 0 && !isOpen)
        {
            isOpen = true;
            DoorUnlockedEvent?.Invoke();
        }
    }
}
