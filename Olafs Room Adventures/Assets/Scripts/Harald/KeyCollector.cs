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
            player.GetComponent<DoorOpener>().collectKey(key_id);
            Destroy(gameObject);
        }
    }
}
