using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCameraBlub : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(angles.x,angles.y,0.0f);
    }
}
