using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfter2Sec : MonoBehaviour
{
    private float InitTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InitTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - InitTime > 2) {
            Destroy(gameObject);
        }
    }
}
