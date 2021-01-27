using UnityEngine;
using UnityEngine.Playables;

namespace DialogueSystem
{
    public class DialogueReceiver : MonoBehaviour, INotificationReceiver
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is DialogueMarker dialogueMarker)
        {
            dialogueTrigger.dialogueText = dialogueMarker.DialogueText;
            dialogueTrigger.TriggerDialogue();
        }
        
    }

}
}

