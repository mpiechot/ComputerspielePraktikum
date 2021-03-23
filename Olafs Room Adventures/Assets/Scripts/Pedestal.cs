using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pedestal : MonoBehaviour
{

    public int id;
    private bool cubeHasDocked = false;
    [SerializeField] private PedestalManager pedestalManager;

    [SerializeField] private UnityEvent OnDocking;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PedestalObject" && !cubeHasDocked) 
        {
            int other_id = other.GetComponent<PedestalObject>().id;
            if (other_id != null)
            {
                if (other_id == this.id) 
                {
                    cubeHasDocked = true;
                    other.transform.localPosition = new Vector3(0.8f, 2.7f, -0.95f);
                    other.transform.eulerAngles = Vector3.zero;
                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.isKinematic = true;

                    OnDocking.Invoke();
                }
            }
        }
    }

}
