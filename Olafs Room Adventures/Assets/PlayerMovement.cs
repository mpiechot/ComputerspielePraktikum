using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    [SerializeField]
    private float keyPressThreshHold = 0.1f;
    [SerializeField]
    private float gravityReduceStepSize = 0.1f;
    [SerializeField]
    private float maxMagnitude = 9.8f;

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        if(verticalInput >= keyPressThreshHold)
        {
            Vector3 newGravity = Camera.main.transform.forward * verticalInput * Time.deltaTime;
            Physics.gravity += newGravity;
            if (Physics.gravity.magnitude > maxMagnitude)
            {
                Physics.gravity = (Physics.gravity / Physics.gravity.magnitude) * maxMagnitude;
            }
        }
        else
        {
            Physics.gravity = Vector3.Lerp(Physics.gravity, Vector3.zero, gravityReduceStepSize);
        }
        //Vector3 direction = new Vector3(0f, 0f, verticalInput).normalized;

        //float targetAngleXY = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg * cam.eulerAngles.z;
        //float targetAngleXZ = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * cam.eulerAngles.y;
        //float angleXY = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngleXY, ref turnSmoothVelocity, turnSmoothTime);
        //float angleXZ = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleXZ, ref turnSmoothVelocity, turnSmoothTime);


    }
}
