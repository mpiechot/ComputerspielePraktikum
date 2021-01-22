using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom : MonoBehaviour
{
    public GameObject currentRoom;
    public GameObject nextRoom;
    public Transform olaf;
    public Vector3 startArea;

    public void DestroyRoom()
    {
        Destroy(currentRoom);
        Instantiate(nextRoom);
        Debug.Log("Room position: " + nextRoom.transform.position);
        olaf.position = startArea;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            DestroyRoom();
        }
    }
}
