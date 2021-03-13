using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRotate : MonoBehaviour
{
    public Transform center;
    private Vector3 turnLeftAngle;
    private Vector3 initAngle;
    private Vector3 olafAngle;
    private bool bTurn = false;
    private bool bTurned = false;
    private float delay = 7.0f;
    private float startTime = 0.0f;
    private float currTime = 0.0f;
    private float speed = 0.5f;
    private GameObject olaf;
    private Vector3 moveWithElevator = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        initAngle = transform.localRotation.eulerAngles;
        turnLeftAngle = initAngle + new Vector3(0, -90, 0);
        olaf = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //olaf.transform.position = center.position;
        //moveWithElevator = center.position - olaf.transform.position;
        //olaf.transform.Translate(moveWithElevator * Time.deltaTime * 5.5f, Space.World);

        if (bTurn)
        {
            
            currTime = Time.time;
            
            if ((currTime - startTime) > delay)
            {
                
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(turnLeftAngle), Time.deltaTime * speed);
                
                moveWithElevator = center.position - olaf.transform.position;
                olaf.transform.position -= moveWithElevator * Time.deltaTime * 0.001f;
                //stop at 90
                if (Mathf.Abs(transform.rotation.eulerAngles.y - turnLeftAngle.y) < 1)
                {
                    bTurn = false;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && bTurned == false)
        {
            bTurn = true;
            bTurned = true;
            startTime = Time.time;
            currTime = Time.time;
        }
        
    }
}
