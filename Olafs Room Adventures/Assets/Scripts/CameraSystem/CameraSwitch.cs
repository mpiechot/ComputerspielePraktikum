using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject oldCam;
    public GameObject newCam;

    public void SwitchCameras()
    {
        SetPriority(oldCam, 1);
        SetPriority(newCam, 20);
    }

    private void SetPriority(GameObject cam, int prio) 
    {
        CinemachineVirtualCamera cvc = cam.GetComponent<CinemachineVirtualCamera>();
        CinemachineFreeLook cfl = cam.GetComponent<CinemachineFreeLook>();

        if (cvc == null && cfl != null)
        {
            cfl.Priority = prio;
            return;
        }
        else if (cfl == null && cvc != null)
        {
            cvc.Priority = prio;
            return;
        }
        else
        {
            Debug.Log("error: cam has both components (virtual cam and free look cam)");
        }
    }

    public void SwitchCamerasBack()
    {
        SetPriority(newCam, 1);
        SetPriority(oldCam, 20);
    }
}
