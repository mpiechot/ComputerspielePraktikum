using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravitySequenceRiddle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent RiddleFailedEvent;
    [SerializeField]
    private UnityEvent RiddleFinishedEvent;
    [SerializeField]
    private SerializablePair<Axis,bool>[] gravitySequence;
    [SerializeField]
    private int currentIndex = 0;

    private void Start()
    {
        currentIndex = 0;
    }
    public void OnGravityChanged()
    {
        SerializablePair<Axis,bool> activePair;
        float gravityValue;
        if(currentIndex >= gravitySequence.Length)
        {
            //GetActivePairAndGravity(gravitySequence.Length-1,out activePair, out gravityValue);
            //if (activePair.value && gravityValue < 0 || !activePair.value && gravityValue > 0)
            //{
            //    RiddleFailedEvent.Invoke();
            //    currentIndex = 0;
            //}
        }
        else
        {
            GetActivePairAndGravity(currentIndex,out activePair, out gravityValue);

            if (activePair.value && gravityValue > 0 || !activePair.value && gravityValue < 0)
            {
                currentIndex++;
                if (currentIndex >= gravitySequence.Length)
                {
                    PuzzleFinished();
                }
            }
            else
            {
                WrongGravity();
            }
        }
    }

    private void GetActivePairAndGravity(int index, out SerializablePair<Axis,bool> activePair, out float gravityValue)
    {
        activePair = gravitySequence[index];
        gravityValue = 0f;
        switch (activePair.key)
        {
            case Axis.X: gravityValue = Physics.gravity.x; break;
            case Axis.Y: gravityValue = Physics.gravity.y; break;
            case Axis.Z: gravityValue = Physics.gravity.z; break;
        }
    }

    private void WrongGravity()
    {
        //Play some sound?
        currentIndex = 0;
    }

    private void PuzzleFinished()
    {
        //Play some sound?
        RiddleFinishedEvent.Invoke();
    }

    private bool GravityBetweenValues(float gravity, float min, float max)
    {
        return gravity >= min && gravity <= max;
    }

}
