using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneLoadElevator : MonoBehaviour
{
    private bool bLevelLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<ReneLevelPartManager>().loadPart("Raum1_Aufzug");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !bLevelLoaded)
        {
            FindObjectOfType<ReneLevelPartManager>().loadPart("Raum1_Aufzug");
            bLevelLoaded = true;
        }
            
    }
}
