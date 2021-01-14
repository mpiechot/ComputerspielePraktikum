using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    private bool played = false;
    private PlayableDirector timeline;

    void Start() 
    {
        timeline = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !played)
        {
            timeline.Play();
            played = true;
        }
    }
}
