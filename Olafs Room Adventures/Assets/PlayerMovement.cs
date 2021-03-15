using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float keyPressThreshHold = 0.1f;
    [SerializeField]
    private float gravityReduceStepSize = 0.1f;
    [SerializeField]
    private float maxMagnitude = 9.8f;
    [SerializeField]
    private float gravityMultiplyer = 3f;

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float zAxisInput = Input.GetAxisRaw("ZAxis");
        if (Mathf.Abs(verticalInput) >= keyPressThreshHold 
            || Mathf.Abs(horizontalInput) >= keyPressThreshHold
            || Mathf.Abs(zAxisInput) >= keyPressThreshHold)
        {
            Vector3 newGravity = Camera.main.transform.forward * verticalInput * gravityMultiplyer * Time.deltaTime;
            newGravity += Camera.main.transform.right * horizontalInput * gravityMultiplyer * Time.deltaTime;
            newGravity += Camera.main.transform.up * zAxisInput * gravityMultiplyer * Time.deltaTime;
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
    }

    private void OnDrawGizmos()
    {
        //float angle = Mathf.Acos(Vector3.Dot(lookDirection, gravityInputVector.normalized));
        var rot = Quaternion.Euler(Camera.main.transform.eulerAngles);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, rot * Physics.gravity * 10);
    }
}
