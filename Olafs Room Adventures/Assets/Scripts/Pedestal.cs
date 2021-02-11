using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    public int id;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PedestalObject") 
        {
            int other_id = other.GetComponent<PedestalObject>().id;
            if (other_id != null)
            {
                if (other_id == this.id) 
                {
                    other.transform.localPosition = new Vector3(0.8f, 2.7f, -0.95f);
                    other.transform.eulerAngles = Vector3.zero;
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }

}
