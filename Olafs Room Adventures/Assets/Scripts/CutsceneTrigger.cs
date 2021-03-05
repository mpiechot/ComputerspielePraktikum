using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public bool passCollider;

    private bool played = false;
    [SerializeField]
    private PlayableDirector timeline;

    public DialogueSystem.DialogueManager dialogueManager;

    void Start() 
    {
        dialogueManager.onCutscene.AddListener((action) => SetCutscene(action));
    }

    public void SetCutscene(string action) 
    {
        GameObject.Find("/Cutscenes/" + action).GetComponent<PlayableDirector>().Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!passCollider && other.tag == "Player" && !played)
        {
            TriggerCutscene();
            played = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (passCollider & other.tag == "Player" && !played) 
        {
            TriggerCutscene();
            played = true;
        }
    }

    public void TriggerCutscene() 
    {
        timeline.Play();
    }
}
