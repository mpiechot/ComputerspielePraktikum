using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClose : MonoBehaviour
{
    public GameObject door;

    private bool closeTheDoor;

    // Start is called before the first frame update
    void Start()
    {
        closeTheDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeTheDoor)
        {
            door.transform.position = Vector3.Lerp(door.transform.position,new Vector3(-10,10,24),0.2f);
        }
        if(door.transform.position.y < 11)
        {
            SceneManager.LoadScene("SecondRoom", LoadSceneMode.Single);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            closeTheDoor = true;
        }
    }
}
