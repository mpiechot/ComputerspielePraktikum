using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightplay : MonoBehaviour
{
    //Light light1;
    [SerializeField]
    private Light light;

    [SerializeField]
    private GameObject nighttop;

    [SerializeField]
    private GameObject cone0,cone1,cone2,cone3,cone4,cone5;

    [SerializeField]
    private GameObject dwall0,dwall1,dwall2,dwall3,dwall4,dwall5,dwall6,dwall7,dwall8;

    [SerializeField]
    private GameObject nwall0,nwall1,nwall2,nwall3,nwall4,nwall5,nwall6,nwall7,nwall8;

    private double delay = 0.5;
	protected float Timer;
    protected float Timer2;

    private bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        deactivateNight();
        deactivateHelp();
        nighttop.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
    	Debug.Log("triggerevent startet");
    	if(other.tag == "Player")
    	{
    		entered = true;
    	}
    }

    void OnTriggerExit(Collider other)
    {
    	Debug.Log("triggerevent endet");
    	if(other.tag == "Player")
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
            Timer2 += Time.deltaTime;

            if (Timer >= delay)
    		{
    			if (light.intensity<1)
    			{
        			light.intensity += (float)0.02;
    			}
    			Timer = 0;
    		}

    		if ((light.intensity >= 0.6) && nwall0.active)
    		{
                deactivateNight();
                activateDay();
                nighttop.SetActive(false);
    		}

			if ((Input.GetKeyDown(KeyCode.L)) && (light.intensity > 0.8))
        	{
           		light.intensity = 0;
                activateNight();
                deactivateDay();
                nighttop.SetActive(true);
       		}

            if (Timer2 >= 600)
            {
                activateHelp();
            }
    	}

    }

    void deactivateNight()
    {
        nwall0.SetActive(false);
        nwall1.SetActive(false);
        nwall2.SetActive(false);
        nwall3.SetActive(false);
        nwall4.SetActive(false);
        nwall5.SetActive(false);
        nwall6.SetActive(false);
        nwall7.SetActive(false);
        nwall8.SetActive(false);
    }

    void activateNight()
    {
        nwall0.SetActive(true);
        nwall1.SetActive(true);
        nwall2.SetActive(true);
        nwall3.SetActive(true);
        nwall4.SetActive(true);
        nwall5.SetActive(true);
        nwall6.SetActive(true);
        nwall7.SetActive(true);
        nwall8.SetActive(true);
    }

    void deactivateDay()
    {
        dwall0.SetActive(false);
        dwall1.SetActive(false);
        dwall2.SetActive(false);
        dwall3.SetActive(false);
        dwall4.SetActive(false);
        dwall5.SetActive(false);
        dwall6.SetActive(false);
        dwall7.SetActive(false);
        dwall8.SetActive(false);
    }

    void activateDay()
    {
        dwall0.SetActive(true);
        dwall1.SetActive(true);
        dwall2.SetActive(true);
        dwall3.SetActive(true);
        dwall4.SetActive(true);
        dwall5.SetActive(true);
        dwall6.SetActive(true);
        dwall7.SetActive(true);
        dwall8.SetActive(true);
    }

    void activateHelp()
    {
        cone0.SetActive(true);
        cone1.SetActive(true);
        cone2.SetActive(true);
        cone3.SetActive(true);
        cone4.SetActive(true);
        cone5.SetActive(true);
    }

    void deactivateHelp()
    {
        cone0.SetActive(false);
        cone1.SetActive(false);
        cone2.SetActive(false);
        cone3.SetActive(false);
        cone4.SetActive(false);
        cone5.SetActive(false);
    }
}
