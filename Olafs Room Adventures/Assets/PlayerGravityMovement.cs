using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityMovement : MonoBehaviour
{
    [Range(0, 100)]
    public float gravityForce = .00000001f;
    public float maxMagnitude = 9.8f;

    public bool bFreeFloating = false;

    private void Start()
    {
        Physics.gravity = Vector3.zero;
    }
    private void Update()
    {
        //Skip Directional changes if Changing Gravity is locked and float in Air until Delay is over
        if (bFreeFloating)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ChangeGravity(new Vector3(0, -gravityForce, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            ChangeGravity(new Vector3(0, gravityForce, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            ChangeGravity(new Vector3(-gravityForce, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            ChangeGravity(new Vector3(gravityForce, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            ChangeGravity(new Vector3(0, 0, -gravityForce));
        }
        if (Input.GetKey(KeyCode.W))
        {
            ChangeGravity(new Vector3(0, 0, gravityForce));
        }

        if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            ChangeGravityToZero(Axis.Y);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ChangeGravityToZero(Axis.X);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
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
        if (Physics.gravity.magnitude > maxMagnitude)
        {
            Physics.gravity = (Physics.gravity / Physics.gravity.magnitude) * maxMagnitude;
        }
    }


    public IEnumerator LockGravityAndFreeFloat(float seconds)
    {
        bFreeFloating = true;
        ChangeGravityToZero(Axis.X);
        ChangeGravityToZero(Axis.Y);
        ChangeGravityToZero(Axis.Z);
        yield return new WaitForSeconds(seconds);
        bFreeFloating = false;
    }

    public void DeactivateGravity()
    {
        ChangeGravityToZero(Axis.X);
        ChangeGravityToZero(Axis.Y);
        ChangeGravityToZero(Axis.Z);
    }
}
