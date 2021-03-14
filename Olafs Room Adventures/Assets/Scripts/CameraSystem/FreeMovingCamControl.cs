using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using TMPro;

public class FreeMovingCamControl : MonoBehaviour
{
    [Header("Rotation speed")]
    public float speedH;
    public float speedV;

    [Header("Movement speed")]
    public float movementSpeed;

    [Header("Scrolling speed")]
    public float scrollSpeed;

    [Header("UI")]
    public bool cameraLocked = true;
    public TextMeshProUGUI btText;

    private float horizontal;
    private float vertical;
    private Vector3 newPos;
    private Vector3 newVelocity;
    private Vector3 newRot;
    private CinemachineVirtualCamera cinemachine;
    private CameraSwitch cameraSwitch;
    private Rigidbody rb;

    void Awake()
    {
        // Initialize variables 
        horizontal = speedH;
        vertical = speedV;
        newVelocity = Vector3.zero;
        cinemachine = transform.GetComponent<CinemachineVirtualCamera>();
        cameraSwitch = transform.GetComponent<CameraSwitch>();
        rb = transform.GetComponent<Rigidbody>();
        if (cameraLocked) 
        {
            LockCam();
        }
        else
        {
            UnlockCam();
        }
    }

    void Update() 
    {
        if (cameraLocked) // switch to orbit camera
        {
            if (Input.GetKeyDown("space"))
            {
                UnlockCam();
            }
        }
        else // free moving cam
        {
            if (Input.GetKeyDown("space"))
            {
                LockCam();
            }
            if (Input.GetMouseButton(1)) // right mouse button pressed -> rotate camera
            {
                horizontal -= speedH * Input.GetAxis("Mouse X");
                vertical += speedV * Input.GetAxis("Mouse Y");
                
                transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
            }
            if (Input.GetMouseButton(2)) // mouse wheel pressed -> move camera upwards or sideways
            {
                newPos = transform.position;
                newPos.y -= speedV * Input.GetAxis("Mouse Y");
                transform.position = newPos;
                transform.position += -transform.right * Input.GetAxisRaw("Mouse X") * movementSpeed;
                // float deltaX = Math.Sign(Input.GetAxis("Mouse X"));
                // if (deltaX != 0) 
                // {
                //     rb.velocity = new Vector3(-deltaX * movementSpeed, 0.0f, 0.0f);
                // } 
                // else 
                // {
                //     rb.velocity = Vector3.zero;
                // }
                // newVelocity = -transform.right * Math.Sign(Input.GetAxis("Mouse X")) * movementSpeed;
                // newVelocity.y -= movementSpeed * Math.Sign(Input.GetAxis("Mouse Y"));
                // rb.velocity = newVelocity;
            }
            // else 
            // {
            //     rb.velocity = Vector3.zero;
            // }
            // rb.angularVelocity = Vector3.zero;

            float zoom_direction = Math.Sign(Input.GetAxis("Mouse ScrollWheel")); // positive -> 1, negative -> -1, zero -> 0
            if (zoom_direction != 0f) // scrolling moves camera forwards or backwards
            {
                transform.Translate(transform.forward * scrollSpeed * zoom_direction, Space.World);
            }
        }
    }

    public void UnlockCam()
    {
        cameraSwitch.SwitchCamerasBack();
        cameraLocked = false;
        btText.text = "cam free";
        transform.position = cameraSwitch.newCam.transform.position;
        transform.rotation = Camera.main.transform.rotation;
        horizontal = Camera.main.transform.eulerAngles.y;
        vertical = Camera.main.transform.eulerAngles.x;
    }

    public void LockCam()
    {
        cameraSwitch.SwitchCameras();
        cameraLocked = true;
        btText.text = "cam locked";
    }

    public void OnButtonClick()
    {
        if (cameraLocked)
        {
            UnlockCam();
        }
        else
        {
            LockCam();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Trigger!!!");
        }
    }
}
