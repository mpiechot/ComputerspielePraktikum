using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOlafBumper : MonoBehaviour
{
    private bool stoped = false;
    public GameObject olaf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !stoped)
        {
            olaf.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            stoped = true;
        }


    }
}
