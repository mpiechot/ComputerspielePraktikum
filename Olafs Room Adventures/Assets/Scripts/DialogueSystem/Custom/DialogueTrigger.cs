using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        public DialogueManager dm;

        public Dialogue dialogue;

        public void TriggerDialogue()
        {
            dm.StartDialogue(dialogue);
        } 
    }
}