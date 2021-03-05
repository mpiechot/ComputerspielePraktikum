using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTestRene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0.0f, Space.Self);
        transform.Rotate(Vector3.left , 45 * 10 * Time.deltaTime);
    }
}
