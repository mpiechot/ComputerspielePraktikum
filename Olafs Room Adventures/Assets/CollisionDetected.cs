using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void OnCollisionEnter(Collision collision)
    {
        player.OnCollide(collision);    
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collided!");
    }
}
