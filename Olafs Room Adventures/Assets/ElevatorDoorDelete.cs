using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorDelete : MonoBehaviour
{
    bool CR_running = false;
    IEnumerator deleteWall()
    {
        CR_running = true;
        yield return new WaitForSeconds(18);
        transform.Find("WallToDelete").gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CR_running)
        {
            StartCoroutine(deleteWall());

        }
    }
}
