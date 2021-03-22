using DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }
    public void Use()
    {
        dialogueTrigger.TriggerDialogue();
    }
}
