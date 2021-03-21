using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (De-)activate player interacction:
//      - Gravity control
//      - Continue button for dialogue
//      - (Camera control)
//      - 
public class PlayerInteraction : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public DialogueSystem.DialogueManager dialogueManager;

    public void ActivatePlayerInteraction() 
    {
        dialogueManager.activeCutscene = false;
    }

    public void DeactivatePlayerInteraction() 
    {
        dialogueManager.activeCutscene = true;
        playerMovement.DeactivateGravity();
    }

}
