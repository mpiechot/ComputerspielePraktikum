using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogueMarker : Marker, INotification, INotificationOptionProvider
{
    [TextArea(3,10)]
    [SerializeField] private string message = "";
    [SerializeField] private float delay = 0.1f;

    [Space(20)]
    [SerializeField] private bool retroactive = false;
    [SerializeField] private bool emitOnce = false;

    // // TextColor
    // // TextAlignment
    // // SpeakerPortrait
    // // etc.

    public PropertyName id => new PropertyName(); // required by INotification but we are actually not using it
    public string Message => message;
    public float Delay => delay; 

    public NotificationFlags flags => 
        (retroactive ? NotificationFlags.Retroactive : default) |
        (emitOnce ? NotificationFlags.TriggerOnce : default);

}