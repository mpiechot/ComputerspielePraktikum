using UnityEngine;
using UnityEngine.Playables;

public class DialogueReceiver : MonoBehaviour, INotificationReceiver
{

    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is DialogueMarker dialogueMarker)
        {
            //dialogueTrigger.TriggerDialogue();
            //Debug.Log(dialogueMarker.Message);
            dialogueTrigger.dialogue.sentences = new string[1];
            dialogueTrigger.dialogue.sentences[0] = dialogueMarker.Message;
            dialogueTrigger.letterDelay = dialogueMarker.Delay;
            dialogueTrigger.TriggerDialogue();
        }
        
    }

}
