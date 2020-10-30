using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineFreeLook cinemachine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cinemachine.m_XAxis.m_InputAxisName = "Mouse X";
            cinemachine.m_YAxis.m_InputAxisName = "Mouse Y";
        }
        else
        {
            cinemachine.m_XAxis.m_InputAxisName = "";
            cinemachine.m_YAxis.m_InputAxisName = "";
            cinemachine.m_XAxis.m_InputAxisValue = 0;
            cinemachine.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
