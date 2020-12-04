using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleExplosionH : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player_root;
    void OnCollisionEnter (Collision coll) {
        if (coll.collider.CompareTag ("Player")) {
            player_root.GetComponent<Rigidbody>().AddForce (Random.Range(-100000,100000),Random.Range(-100000,100000),Random.Range(-100000,100000));
            Explode ();
            
        }
    }
    void Explode () {
        GameObject explosion_objects = Instantiate(explosion, transform.position, Quaternion.identity);
        explosion_objects.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
