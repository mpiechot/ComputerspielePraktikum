using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerAway : MonoBehaviour
{
    [SerializeField]
    private Vector3 Directions = new Vector3(0, 0, 0);
    private float speed = 10.2f;
    private bool pushOlafOut = false;
    private GameObject Olaf;
    
    // Start is called before the first frame update
    void Start()
    {
        Olaf = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {

        if (pushOlafOut)
        {
            Olaf.transform.position = Olaf.transform.position + Directions * Time.deltaTime * speed;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pushOlafOut = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
             pushOlafOut = false;
        }
    }
}
