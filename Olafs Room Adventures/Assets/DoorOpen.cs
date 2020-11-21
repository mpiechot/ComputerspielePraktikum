using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
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
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(-10, 20, 24), 0.2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            closeTheDoor = true;
        }
    }
}
