﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcontroll : MonoBehaviour
{
    [SerializeField]
    private Light[] lights;

    [SerializeField]
    private float value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Light l in lights)
        {
            l.intensity = value;
        }
    }
}
