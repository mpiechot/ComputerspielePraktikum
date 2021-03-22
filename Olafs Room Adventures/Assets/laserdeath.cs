using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserdeath : MonoBehaviour
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindObjectOfType<Player>().GetComponent<Player>().TakeDamage(25);
        }
    }
}
