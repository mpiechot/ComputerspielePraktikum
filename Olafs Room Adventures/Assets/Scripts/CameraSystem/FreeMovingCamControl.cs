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
    //public TextMeshProUGUI btText;

    [Header("Settings")]
    public bool invert;
    public float rayCastLength;

    private float horizontal;
    private float vertical;
    private Vector3 newPos;
    private Vector3 newVelocity;
    private Vector3 newRot;
    private CinemachineVirtualCamera cinemachine;
    private CameraSwitch cameraSwitch;
    private Rigidbody rb;
    private int dir;

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

        dir = invert ? 1 : -1;
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
                horizontal -= dir * speedH * Input.GetAxis("Mouse X");
                vertical += speedV * Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
            }
            if (Input.GetMouseButton(2)) // mouse wheel pressed -> move camera upwards or sideways
            {
                bool moveHorizontal = true;
                bool moveVertical = true;

                float mouseX = Input.GetAxisRaw("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                if (mouseX < 0) // right
                {
                    moveHorizontal = RaycastsHitWall(transform.right,
                                                    (transform.forward + transform.right + transform.up),
                                                    (transform.forward - transform.right - transform.up),
                                                    (-transform.forward + transform.right + transform.up),
                                                    (-transform.forward - transform.right - transform.up));
                }
                else if (mouseX > 0) // left
                {
                    moveHorizontal = RaycastsHitWall(-transform.right,
                                                    (transform.forward - transform.right + transform.up),
                                                    (transform.forward - transform.right - transform.up),
                                                    (-transform.forward - transform.right + transform.up),
                                                    (-transform.forward - transform.right - transform.up));
                }

                if (mouseY < 0) // up
                {
                    moveVertical = RaycastsHitWall(transform.up,
                                                  (transform.forward + transform.right + transform.up),
                                                  (transform.forward - transform.right + transform.up),
                                                  (-transform.forward + transform.right + transform.up),
                                                  (-transform.forward - transform.right + transform.up));
                }
                else if (mouseY > 0) // down
                {
                    moveVertical = RaycastsHitWall(-transform.up,
                                                  (transform.forward + transform.right - transform.up),
                                                  (transform.forward - transform.right - transform.up),
                                                  (-transform.forward + transform.right - transform.up),
                                                  (-transform.forward - transform.right - transform.up));
                }

                if (moveVertical)
                {
                    newPos = transform.position;
                    newPos.y -= speedV * Input.GetAxis("Mouse Y");
                    transform.position = newPos;
                }
                if (moveHorizontal)
                {
                    transform.position += dir * transform.right * Input.GetAxisRaw("Mouse X") * movementSpeed;
                }

            }

            float zoom_direction = Math.Sign(Input.GetAxis("Mouse ScrollWheel")); // positive -> 1, negative -> -1, zero -> 0
            if (zoom_direction != 0f) // scrolling moves camera forwards or backwards
            {
                bool moveForwardBackward = true;

                if (zoom_direction < 0) // back
                {
                    moveForwardBackward = RaycastsHitWall(-transform.forward,
                                                         (-transform.forward + transform.right + transform.up),
                                                         (-transform.forward + transform.right - transform.up),
                                                         (-transform.forward - transform.right + transform.up),
                                                         (-transform.forward - transform.right - transform.up));
                }
                else if (zoom_direction > 0) // front
                {
                    moveForwardBackward = RaycastsHitWall(transform.forward, 
                                                         (transform.forward + transform.right + transform.up), 
                                                         (transform.forward + transform.right - transform.up), 
                                                         (transform.forward - transform.right + transform.up), 
                                                         (transform.forward - transform.right - transform.up));
                }

                if (moveForwardBackward)
                {
                    transform.Translate(transform.forward * scrollSpeed * zoom_direction, Space.World);
                }
            
            } 
        }
    }

    private bool RaycastsHitWall(Vector3 dir0, Vector3 dir1, Vector3 dir2, Vector3 dir3, Vector3 dir4) 
    {
        Debug.DrawRay(transform.position, dir0 * rayCastLength, Color.yellow);
        Debug.DrawRay(transform.position, dir1 * rayCastLength, Color.yellow);
        Debug.DrawRay(transform.position, dir2 * rayCastLength, Color.yellow);
        Debug.DrawRay(transform.position, dir3 * rayCastLength, Color.yellow);
        Debug.DrawRay(transform.position, dir4 * rayCastLength, Color.yellow);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, dir0, out hit, rayCastLength))
        {
            return !WallCollision(hit);
        }
        else if (Physics.Raycast(transform.position, dir1, out hit, 2 * rayCastLength))
        {
            return !WallCollision(hit);
        }
        else if (Physics.Raycast(transform.position, dir2, out hit, 2 * rayCastLength))
        {
            return !WallCollision(hit);
        }
        else if (Physics.Raycast(transform.position, dir3, out hit, 2 * rayCastLength))
        {
            return !WallCollision(hit);
        }
        else if (Physics.Raycast(transform.position, dir4, out hit, 2 * rayCastLength))
        {
            return !WallCollision(hit);
        }
        else
        {
            return true;
        }
    }

    private bool WallCollision(RaycastHit hit) 
    {
        return hit.transform.tag == "Wall";
    }

    public void UnlockCam()
    {
        cameraSwitch.SwitchCamerasBack();
        cameraLocked = false;
        //btText.text = "cam free";
        transform.position = cameraSwitch.newCam.transform.position;
        transform.rotation = Camera.main.transform.rotation;
        horizontal = Camera.main.transform.eulerAngles.y;
        vertical = Camera.main.transform.eulerAngles.x;
    }

    public void LockCam()
    {
        cameraSwitch.SwitchCameras();
        cameraLocked = true;
        //btText.text = "cam locked";
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
