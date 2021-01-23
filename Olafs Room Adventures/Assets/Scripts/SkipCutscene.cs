using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector currentTimeline;

    [SerializeField]
    private PlayableDirector skipTimeline;

    [SerializeField]
    private Animator dialogueBoxAnimator;

    [SerializeField]
    private GameObject skipButton;

    public void Skip()
    {
        dialogueBoxAnimator.SetBool("isOpen", false);
        currentTimeline.Stop();
        skipButton.SetActive(false);
        skipTimeline.Play();
    }

}
