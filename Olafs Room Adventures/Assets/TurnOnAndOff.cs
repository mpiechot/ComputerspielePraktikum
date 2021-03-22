using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnAndOff : MonoBehaviour
{
    [SerializeField]
    private Light light;
    [SerializeField]
    private bool random = true;

    private bool active = true;
    private bool CR = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!CR && random)
        {
            StartCoroutine(Flicker());    
        }

        


    }

    private IEnumerator Flicker()
    {
        CR = true;
        float time = Random.Range(0.2f, 2f);
        active =  !active;
        light.enabled = active;
        Debug.Log("active " + active);
        yield return new WaitForSeconds(time);
        CR = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            light.enabled = true;
        }
    }
}
