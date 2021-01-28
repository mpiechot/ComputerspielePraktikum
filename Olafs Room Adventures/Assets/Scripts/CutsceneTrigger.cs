using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public bool passCollider;

    private bool played = false;
    [SerializeField]
    private PlayableDirector timeline;

    void OnTriggerEnter(Collider other)
    {
        if (!passCollider && other.tag == "Player" && !played)
        {
            TriggerCutscene();
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (passCollider & other.tag == "Player" && !played) 
        {
            TriggerCutscene();
        }
    }

    private void TriggerCutscene() 
    {
        timeline.Play();
            played = true;
    }
}
