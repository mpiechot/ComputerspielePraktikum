using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectTargetArea : MonoBehaviour
{
    [SerializeField]
    private UnityEvent allAtTargetEvent;
    [SerializeField]
    private int keysToTouch = 0;

    private int actualInTouch = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Key")
        {
            actualInTouch++;
            if(actualInTouch == keysToTouch)
            {
                allAtTargetEvent.Invoke();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Key")
        {
            if(actualInTouch < keysToTouch)
            {
                actualInTouch--;
            }
        }
    }
}
