using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    private bool played = false;
    [SerializeField]
    private PlayableDirector timeline;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !played)
        {
            timeline.Play();
            played = true;
        }
    }
}
