using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameGravity : MonoBehaviour
{
    public float gravity = 90f;

    public void ChangeGravityPositiveX()
    {
        Physics.gravity = new Vector3(gravity, 0, 0);
    }
    public void ChangeGravityNegativeX()
    {
        Physics.gravity = new Vector3(-gravity, 0, 0);
    }
    public void ChangeGravityPositiveY()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }
    public void ChangeGravityNegativeY()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
    }
    public void ChangeGravityPositiveZ()
    {
        Physics.gravity = new Vector3(0, 0, gravity);
    }
    public void ChangeGravityNegativeZ()
    {
        Physics.gravity = new Vector3(0, 0, -gravity);
    }
    public void ChangeGravityToZero()
    {
        Physics.gravity = new Vector3(0, 0, 0);
    }
}
