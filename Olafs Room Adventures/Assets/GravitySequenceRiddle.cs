using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravitySequenceRiddle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent RiddleFinishedEvent;
    [SerializeField]
    private SerializablePair[] gravitySequence;
    [SerializeField]
    private int currentIndex = 0;

    private void Start()
    {
        currentIndex = 0;
    }
    public void OnGravityChanged()
    {
        if(currentIndex < gravitySequence.Length)
        {
            SerializablePair activePair = gravitySequence[currentIndex];
            float gravityValue = 0f;
            switch (activePair.axis)
            {
                case Axis.X: gravityValue = Physics.gravity.x; break;
                case Axis.Y: gravityValue = Physics.gravity.y; break;
                case Axis.Z: gravityValue = Physics.gravity.z; break;
            }
            
            if (activePair.direction && gravityValue > 0 || !activePair.direction && gravityValue < 0 )
            {
                currentIndex++;
                if(currentIndex >= gravitySequence.Length)
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
