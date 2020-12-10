using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0,100)]
    public float gravityForce = .00000001f;
    public float maxMagnitude = 9.8f;

    private bool  bFreeFloating = false;
    private float timeWhenLocked = 0f;
    private float lockGravityDelay = 0f;

    private void Start()
    {
        Physics.gravity = Vector3.zero;
    }
    private void Update()
    {
        //Skip Directional changes if Changing Gravity is locked and float in Air until Delay is over
        if (bFreeFloating)  
        {
            ChangeGravityToZero(Axis.X);
            ChangeGravityToZero(Axis.Y);
            ChangeGravityToZero(Axis.Z);
            return; 
        }

        if (Input.GetKey(KeyCode.B))
        {
            ChangeGravity(new Vector3(0, -gravityForce, 0));
        }
        if (Input.GetKey(KeyCode.R))
        {
            ChangeGravity(new Vector3(0, gravityForce, 0));
        }
        if (Input.GetKey(KeyCode.T))
        {
            ChangeGravity(new Vector3(-gravityForce, 0, 0));
        }
        if (Input.GetKey(KeyCode.Y))
        {
            ChangeGravity(new Vector3(gravityForce, 0, 0));
        }
        if (Input.GetKey(KeyCode.P))
        {
            ChangeGravity(new Vector3(0, 0, -gravityForce));
        }
        if (Input.GetKey(KeyCode.G))
        {
            ChangeGravity(new Vector3(0, 0, gravityForce));
        }

        if (!Input.GetKey(KeyCode.R) && !Input.GetKey(KeyCode.B))
        {
            ChangeGravityToZero(Axis.Y);
        }
        if (!Input.GetKey(KeyCode.T) && !Input.GetKey(KeyCode.Y))
        {
            ChangeGravityToZero(Axis.X);
        }
        if (!Input.GetKey(KeyCode.P) && !Input.GetKey(KeyCode.G))
        {
            ChangeGravityToZero(Axis.Z);
        }

    }
    private void ChangeGravityToZero(Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                Physics.gravity = new Vector3(0, Physics.gravity.y, Physics.gravity.z);
                break;
            case Axis.Y:
                Physics.gravity = new Vector3(Physics.gravity.x, 0, Physics.gravity.z);
                break;
            case Axis.Z:
                Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, 0);
                break;
        }
    }
    private void ChangeGravity(Vector3 gravity)
    {      
        Physics.gravity += gravity;
        if(Physics.gravity.magnitude > maxMagnitude)
        {
            Physics.gravity = (Physics.gravity / Physics.gravity.magnitude) * maxMagnitude;
        }
    }


    public IEnumerator LockGravityAndFreeFloat(float seconds) 
    {
        bFreeFloating = true;
        yield return new WaitForSeconds(seconds);
        bFreeFloating = false;
    }
}
