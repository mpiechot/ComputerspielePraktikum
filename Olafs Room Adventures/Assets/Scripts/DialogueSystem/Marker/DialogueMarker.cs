using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogueMarker : Marker, INotification, INotificationOptionProvider
{
    [SerializeField] private Dialogue dialogueText;

    [Space(20)]
    [SerializeField] private bool retroactive = false;
    [SerializeField] private bool emitOnce = false;

    // // TextColor
    // // TextAlignment
    // // SpeakerPortrait
    // // etc.

    public PropertyName id => new PropertyName(); // required by INotification but we are actually not using it
    public Dialogue DialogueText => dialogueText;

    public NotificationFlags flags => 
        (retroactive ? NotificationFlags.Retroactive : default) |
        (emitOnce ? NotificationFlags.TriggerOnce : default);

}