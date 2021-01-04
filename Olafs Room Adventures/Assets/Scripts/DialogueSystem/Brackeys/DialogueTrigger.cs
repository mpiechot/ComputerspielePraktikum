using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    public float letterDelay;

    public void TriggerDialogue() 
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        dialogueManager.StartDialogue(dialogue, letterDelay); // brackeys meinte was von Singleton...?
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogueManager.StartDialogue(dialogue, letterDelay);
        }
    }
}
