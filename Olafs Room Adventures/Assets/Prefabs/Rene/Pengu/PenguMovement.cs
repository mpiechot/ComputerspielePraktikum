﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguMovement : MonoBehaviour
{
    public bool floatsAround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (floatsAround)
        {
            transform.Rotate(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0.0f, Space.Self);
        }
    }
}
