 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class FreeMovingCamControl : MonoBehaviour
{
    [Header("Rotation speed")]
    public float speedH;
    public float speedV;

    [Header("Movement speed")]
    public float movementSpeed;

    [Header("Scrolling speed")]
    public float scrollSpeed;

    [Header("Player transform")]
    public Transform olaf;

    private float horizontal;
    private float vertical;
    private Vector3 newPos;
    private Vector3 newRot;

    private CinemachineFreeLook cinemachine;

    void Awake()
    {
        // Initialize variables 
        horizontal = speedH;
        vertical = speedV;
        cinemachine = transform.GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) // move camera back to Olaf upon pressing space
        {
            FocusOlaf();
        }

        if (Input.GetMouseButton(1)) // right mouse button pressed -> rotate camera
        {
            DetachFromOlaf();
            horizontal += speedH * Input.GetAxis("Mouse X");
            vertical -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
        }
        else // prevent rotating camera without clicking any button (just cinemachine stuff that happens otherwise)
        {
            cinemachine.m_XAxis.m_InputAxisName = "";
            cinemachine.m_YAxis.m_InputAxisName = "";
            cinemachine.m_XAxis.m_InputAxisValue = 0;
            cinemachine.m_YAxis.m_InputAxisValue = 0;
        }

        if (Input.GetMouseButton(2)) // mouse wheel pressed -> move camera upwards or sideways
        {  
            DetachFromOlaf();
            newPos = transform.position;    
            newPos.y -= speedV * Input.GetAxis("Mouse Y");
            transform.position = newPos;
            transform.Translate(-Camera.main.transform.right * Input.GetAxisRaw("Mouse X") * movementSpeed, Space.World);
        }
        
        float zoom_direction = Math.Sign(Input.GetAxis("Mouse ScrollWheel")); // positive -> 1, negative -> -1, zero -> 0
        if (zoom_direction != 0f ) // scrolling moves camera forwards or backwards
        {
            DetachFromOlaf();
            transform.Translate(Camera.main.transform.forward * scrollSpeed * zoom_direction, Space.World);
        }


    }

    // Reset camera, so it is not attached to Olaf anymore
    public void DetachFromOlaf()
    {
        cinemachine.m_Follow = null;
        cinemachine.m_LookAt = null;
    }

    public void FocusOlaf()
    {
        cinemachine.m_Follow = olaf;
        cinemachine.m_LookAt = olaf;
        transform.eulerAngles = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
        if (other.gameObject.layer == 13) // layer 13: Wall
        {
            Debug.Log("Hit wall");
        }
    }

}
