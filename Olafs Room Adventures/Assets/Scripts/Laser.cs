using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPostion;
    [SerializeField]
    private Vector3 endPostion;
    [SerializeField]
    private float speed;

    private bool endReached = false;

    // Update is called once per frame
    void Update()
    {
        if (!endReached)
        {
            transform.position = Vector3.Lerp(transform.position, endPostion, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPostion) < 1f)
            {
                endReached = true;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPostion, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position,startPostion) < 1f)
            {
                endReached = false;
            }
        }
    }
}
