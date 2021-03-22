using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneLoadElevator : MonoBehaviour
{
    private bool bLevelLoaded = false;
    [SerializeField]
    private bool Ontrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!Ontrigger)
        {
            FindObjectOfType<ReneLevelPartManager>().loadPart("Raum1_Aufzug");
            FindObjectOfType<ReneLevelPartManager>().loadPart("Raum1_Part1");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !bLevelLoaded && Ontrigger)
        {
            //FindObjectOfType<ReneLevelPartManager>()
            FindObjectOfType<ReneLevelPartManager>().loadPart("Raum1_Part2");
            FindObjectOfType<ReneLevelPartManager>().unLoadPart("Raum1_Part1");
            bLevelLoaded = true;
        }
            
    }
}
