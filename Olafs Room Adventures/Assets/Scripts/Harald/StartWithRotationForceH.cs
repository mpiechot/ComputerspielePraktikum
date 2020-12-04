using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWithRotationForceH : MonoBehaviour
{
    // Start is called before the first frame update
    public float torque;
    void Start()
    {
        float turn = Input.GetAxis("Horizontal");
        transform.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-100f,100f),Random.Range(-100f,100f),Random.Range(-100f,100f)));
    }

}
