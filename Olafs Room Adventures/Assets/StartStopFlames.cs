using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopFlames : MonoBehaviour
{
    public ParticleSystem[] Flames;
    //public List<GameObject> Flames = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Flames[i].Stop();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startFlames()
    {
        for (int i = 0; i < 4; i++)
        {
            Flames[i].Play();
        }
    }
}
