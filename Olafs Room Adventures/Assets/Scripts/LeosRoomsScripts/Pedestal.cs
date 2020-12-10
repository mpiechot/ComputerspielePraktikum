using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    // Checks if object is a key. If so it positions the key inside the 
    // empty pedestal. If the pedestal is already occupied by a key,
    // nothing happens.
    void OnTriggerEnter(Collider other)
    {
        if (this.transform.childCount < 1 && other.tag == "Key") 
        {
            other.transform.parent = this.transform;
            other.GetComponent<Rigidbody>().isKinematic = true; // freeze object

            other.transform.eulerAngles = new Vector3(
                0.0f,
                0.0f,
                -90.0f                
            );

            Vector3 positionInPedestal = new Vector3(0.5f, 1f, -1f);
            other.transform.localPosition = positionInPedestal;

            PedestalManager.activatedPedestals++;
        }
    }

}
