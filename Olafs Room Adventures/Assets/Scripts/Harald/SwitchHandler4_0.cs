using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler4_0 : MonoBehaviour
{
    public GameObject olaf;
    public GameObject interact_icon;
    public float distance_threshold;
    private bool state = false;

    private void Update()
    {
        if (!state && distance(olaf.transform.position, transform.position) < distance_threshold)
        {
            interact_icon.SetActive(true);
            //show press space
            if(Input.GetKeyDown(KeyCode.Space)){
                state = true;
                //GetComponent<Switch>().SwitchOn();
                GetComponent<CutsceneTrigger>().TriggerCutscene();
            }
        }
        else{
            // Dont show press space
            interact_icon.SetActive(false);
        }
    }

    float distance(Vector3 pos0, Vector3 pos1)
    {
        return (pos0 - pos1).magnitude;
    }
}
