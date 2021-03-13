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
    // Start is called before the first frame update
    void Start()
    {
        initAngle = transform.localRotation.eulerAngles;
        turnLeftAngle = initAngle + new Vector3(0, -90, 0);
        olaf = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bTurn)
        {
            
            currTime = Time.time;
            
            if ((currTime - startTime) > delay)
            {
                
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(turnLeftAngle), Time.deltaTime * speed);
                Vector3 moveWithElevator = new Vector3(0,0,0);
                moveWithElevator = center.position - olaf.transform.position;
                olaf.transform.Translate(moveWithElevator * Time.deltaTime * 0.05f, Space.World);
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
