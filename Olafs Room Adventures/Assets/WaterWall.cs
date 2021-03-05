using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWall : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            GameObject.FindObjectOfType<Player>().GetComponent<Player>().stopFireDamage();


        }

    }

}
