using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;


public class CameraController : MonoBehaviour
{
    public CinemachineFreeLook cinemachine;
    public float zoom_speed = 1;

    public bool deactivated;

    // Update is called once per frame
    void Update()
    {

        if (deactivated)
        {
            return;
        }

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

        // positive -> 1, negative -> -1, zero -> 0
        float zoom_direction = Math.Sign(Input.GetAxis("Mouse ScrollWheel"));
        if (zoom_direction != 0f) // forward
        {
            cinemachine.m_Orbits[0].m_Height -= zoom_direction * zoom_speed;
            cinemachine.m_Orbits[1].m_Radius -= zoom_direction * zoom_speed;
            cinemachine.m_Orbits[2].m_Height += zoom_direction * zoom_speed;
        }

    }

    public void shakeCamera(float amplitude, float duration)
    {
        StartCoroutine(startShake(amplitude, duration));
    }

    IEnumerator startShake(float amplitude, float duration)
    {
        cinemachine.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cinemachine.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cinemachine.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(duration / 10);
            amplitude = amplitude - amplitude / 10;
            cinemachine.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
            cinemachine.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
            cinemachine.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        }
        //yield return WaitForSeconds(duration/10);
        cinemachine.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        cinemachine.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        cinemachine.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }


}
