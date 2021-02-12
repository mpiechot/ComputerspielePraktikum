using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public int numberOfPedestals;
    private int currentlyActivated;

    [SerializeField] private CutsceneTrigger cutsceneTrigger;

    public void OnDockingEvent() 
    {
        currentlyActivated++;
        if (currentlyActivated == numberOfPedestals)
        {
            Debug.Log("Pedestals activated");
            cutsceneTrigger.TriggerCutscene();
        }
    }
}
