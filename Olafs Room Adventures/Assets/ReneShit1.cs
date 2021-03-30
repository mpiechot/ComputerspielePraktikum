using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneShit1 : MonoBehaviour
{
    [SerializeField]
    private Vector3 Directions = new Vector3(0, 0, 0);
    private float speed = 10.2f;
    private float magnitude = 3f;
    private bool pushOlafOut = false;
    private GameObject Olaf;
    private bool triggered = false;
    private bool CR = false; 

    //[SerializeField]
    //private Transform Ziel;

    // Start is called before the first frame update
    void Start()
    {
        Directions *= magnitude;
        Olaf = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (pushOlafOut)
        {
            Olaf.transform.position = Olaf.transform.position - new Vector3(0,2,0);
            Debug.LogWarning("tp");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!CR)
            {
                StartCoroutine(tp());
            }
            if (triggered)
            {
                pushOlafOut = true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pushOlafOut = false;
        }
    }
    private IEnumerator tp()
    {
        CR = true;
        yield return new WaitForSeconds(7);
        triggered = true;
        
    
    }
}
