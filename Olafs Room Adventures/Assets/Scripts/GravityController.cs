using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    private GravityControls controls;

    [Range(0,100)]
    public float gravityForce = 9.8f;

    void Awake()
    {
        controls = new GravityControls();
        controls.Player.Blue.performed += _ => ChangeGravity(new Vector3(0, -gravityForce, 0));
        controls.Player.Red.performed += _ => ChangeGravity(new Vector3(0, gravityForce, 0));
        controls.Player.Turquoise.performed += _ => ChangeGravity(new Vector3(-gravityForce, 0, 0));
        controls.Player.Yellow.performed += _ => ChangeGravity(new Vector3(gravityForce, 0, 0));
        controls.Player.Pink.performed += _ => ChangeGravity(new Vector3(0, 0, -gravityForce));
        controls.Player.Green.performed += _ => ChangeGravity(new Vector3(0, 0, gravityForce));
    }

    private void ChangeGravity(Vector3 gravity)
    {
        Physics.gravity = gravity;
    }

    #region ControlSettings
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    #endregion
}
