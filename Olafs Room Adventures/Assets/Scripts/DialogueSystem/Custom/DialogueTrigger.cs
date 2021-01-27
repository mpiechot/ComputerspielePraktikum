using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        public DialogueManager dm;
        public Dialogue dialogueText;

        public void TriggerDialogue()
        {
            dm.StartDialogue(dialogueText);
        } 
    }
}