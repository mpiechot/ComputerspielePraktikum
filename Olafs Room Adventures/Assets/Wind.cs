using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private ParticleSystem ps;

    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Play();
    }

    public void Update()
    {
        if (ps)
        {           
            if (ps.isStopped)
            {
                Destroy(gameObject);
            }
        }
    }
}
