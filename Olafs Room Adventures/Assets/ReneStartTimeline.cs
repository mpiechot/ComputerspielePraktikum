using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;


public class ReneStartTimeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public CinemachineFreeLook FreeLook;

    private bool CR = false;
    [SerializeField]
    private bool bStart = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (bStart)
                timeline.Play();

            if (!bStart)
                timeline.Stop();

        }
    }

    
}
