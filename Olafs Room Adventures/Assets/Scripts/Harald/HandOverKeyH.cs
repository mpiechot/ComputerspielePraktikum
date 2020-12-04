using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOverKeyH : MonoBehaviour
{
    public GameObject olaf;
    void OnCollisionEnter (Collision coll) {
        if (coll.collider.CompareTag ("Player")) {
            olaf.GetComponent<OlafStatesH>().has_key = true;
            Debug.Log("key was transfered to olaf");
            Destroy(gameObject);
        }
    }
}
