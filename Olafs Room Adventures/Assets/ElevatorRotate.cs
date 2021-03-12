using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRotate : MonoBehaviour
{
    private Vector3 turnLeftAngle;
    private Vector3 initAngle;
    private bool bTurn = false;
    private float delay = 3.0f;
    private float startTime = 0.0f;
    private float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        initAngle = transform.localRotation.eulerAngles;
        turnLeftAngle = initAngle + new Vector3(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (bTurn && Mathf.Abs( Time.time - startTime) > startTime)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(turnLeftAngle), Time.deltaTime * speed);

            //stop at 90
            if (Mathf.Abs(transform.rotation.eulerAngles.y - turnLeftAngle.y) < 1)
            {
                bTurn = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bTurn = true;    
        }
        startTime = Time.time;
    }
}
