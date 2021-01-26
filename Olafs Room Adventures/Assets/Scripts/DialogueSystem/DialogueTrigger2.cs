using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;
    public TMP_Animated tmp_Animated;

    public float letterDelay;

    public UnityEvent testevent;

    public void TriggerDialogue2() 
    {
        tmp_Animated.StartDialogue(dialogue, letterDelay);
    }
}