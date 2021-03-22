using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEntity : MonoBehaviour
{
    public GameObject entity;

    // Update is called once per frame
    void Update()
    {
        transform.position = entity.transform.position;
        transform.eulerAngles = entity.transform.eulerAngles;
    }
}
