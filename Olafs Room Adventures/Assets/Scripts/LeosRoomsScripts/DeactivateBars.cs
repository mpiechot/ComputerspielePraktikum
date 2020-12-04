using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBars : MonoBehaviour {

    public GameObject bars;

    void OnTriggerStay(Collider other) {
        //Debug.Log("Hello world");
        
        if (other.gameObject.tag == "Player") {
            if (Input.GetKeyDown("space")) {
                Debug.Log("Bars deactivated");
                bars.SetActive(false);
            }
        }
    }

}
