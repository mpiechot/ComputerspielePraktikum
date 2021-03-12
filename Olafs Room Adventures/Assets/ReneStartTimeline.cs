using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;


public class ReneStartTimeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public CinemachineFreeLook cinemashine;
    public GameObject olaf;

    private bool CR = false;
    [SerializeField]
    private bool bStart = true;
    [SerializeField]
    private bool camFollows = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (bStart) 
            {
                //timeline.Play();
                if (camFollows && !CR)
                {
                    StartCoroutine("changeView");
                }
            }
                
                

            if (!bStart)
                timeline.Stop();

        }
    }

    IEnumerator changeView()
    {
        CR = true;

        yield return new WaitForSeconds(2);
        //cinemashine.Follow = null;
        //cinemashine.LookAt = null;
        cinemashine.ForceCameraPosition(olaf.transform.position + new Vector3(0, 0, 60), Quaternion.Euler(new Vector3(0,0,0)));
        cinemashine.Follow = olaf.transform;
        cinemashine.LookAt = olaf.transform;
        
    }
}
