using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartBrianCutscene : MonoBehaviour
{
    public PlayableDirector timeline;
    private ReneStartSong song;
    public StartStopFlames flames;
    private bool CR = false;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        song = FindObjectOfType<ReneStartSong>();
        //flames = FindObjectOfType<StartStopFlames>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !played)
        {
            if (CR == false)
            {
                StartCoroutine("FlameAndNewSong");
                Debug.Log("start CR");
            }


            played = true;
            timeline.Play();
            
        }
    }

    IEnumerator FlameAndNewSong()
    {
        CR = true;
        
        yield return new WaitForSeconds(2);
        song.playNewSong();
        
        yield return new WaitForSeconds(7);
        flames.startFlames();
        Debug.Log("guitaaarr");
        song.playGuitar();
        
       
    }
}
