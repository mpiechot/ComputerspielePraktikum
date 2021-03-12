using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler4_0 : MonoBehaviour
{
    public GameObject olaf;
    public float distance_threshold;
    private bool state = false;

    private void Update()
    {
        if (!state && distance(olaf.transform.position, transform.position) < distance_threshold)
        {
            //show press space
            if(Input.GetKeyDown(KeyCode.Space)){
                state = true;
                //GetComponent<Switch>().SwitchOn();
                GetComponent<CutsceneTrigger>().TriggerCutscene();
            }
        }
        else{
            // Dont show press space
        }
    }

    float distance(Vector3 pos0, Vector3 pos1)
    {
        return (pos0 - pos1).magnitude;
    }
}
