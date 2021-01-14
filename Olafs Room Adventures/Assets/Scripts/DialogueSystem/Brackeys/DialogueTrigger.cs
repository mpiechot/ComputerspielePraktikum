using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    public float letterDelay;

    public UnityEvent testevent;

    public void TriggerDialogue() 
    {
        dialogueManager.StartDialogue(dialogue, letterDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogueManager.StartDialogue(dialogue, letterDelay);
        }
    }
}
