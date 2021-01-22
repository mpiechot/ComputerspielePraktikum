using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightplay : MonoBehaviour
{
	//Light light1;
	public Light light;
	public GameObject mesh;
	private double delay = 0.5;
	protected float Timer;
	private bool entered = true;

    // Start is called before the first frame update
    void Start()
    {
		//light = GetComponent<Light> ();
		//light.intensity = 0; 
    }

    void onTriggerEnter(Collider other)
    {
    	Debug.Log("triggerevent startet");
    	if(other.gameObject.tag == "Player")
    	{
    		entered = true;
    	}
    }

    void onTriggerExit(Collider other)
    {
    	Debug.Log("triggerevent endet");
    	if(other.gameObject.tag == "Player")
    	{
    		entered = false;
    	}
    }



    // Update is called once per frame
    void Update()
    {
    	if (entered)
    	{
    		Timer += Time.deltaTime;

    		if (Timer >= delay)
    		{
    			if (light.intensity<1)
    			{
        			light.intensity += (float)0.02;
    			}
    			Timer = 0;
    		}

    		if ((light.intensity >= 0.6) && (!mesh.active))
    		{
    			mesh.active = true;
    		}

			if ((Input.GetKeyDown(KeyCode.L)) && (light.intensity > 0.8))
        	{
           		light.intensity = 0;
           		mesh.active = false;
           		Debug.Log("pressed Space");
       		}
    	}

    }
}
