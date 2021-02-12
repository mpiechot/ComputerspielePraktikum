using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public int key_id;
    public GameObject player;

    void OnCollisionEnter (Collision coll) {
        if (coll.collider.CompareTag ("Player")) {
            Debug.Log("Key collected " + key_id);
            player.GetComponent<DoorOpener>().keys_collected[key_id] = true;
            Destroy(gameObject);
        }
    }
}
