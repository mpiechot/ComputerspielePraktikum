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
    public GravityController gravityControl;
    public DialogueSystem.DialogueManager dialogueManager;

    public void ActivatePlayerInteraction() 
    {
        dialogueManager.activeCutscene = false;
        gravityControl.bFreeFloating = false;
    }

    public void DeactivatePlayerInteraction() 
    {
        dialogueManager.activeCutscene = true;
        gravityControl.bFreeFloating = true;
        gravityControl.DeactivateGravity();
    }

}
