using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int maxDamage = 25;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private Sprite skin;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private float invincibleTime;
    [SerializeField, Range(0, 300)]
    private float wallDamageThreshold;

    private bool invincible;
    private bool bIsOnFire = false;
    private bool CR_TakeDmgIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar?.setMaxHealth(maxHealth);
    }

    void TakeDamage(int dmg)
    {
        dmg = Mathf.Clamp(dmg, 0, maxDamage);
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Die();
        }
        healthBar?.setHealth(currentHealth);
    }
    void Die()
    {
        Destroy(gameObject);
    }



    public void OnCollide(Collision collision)
    {
        if (invincible)
        {

        }
        else
        {
            CollisionHandling(collision);
        }
    }

    private void CollisionHandling(Collision collision)
    {
        if (collision.collider.tag == "NoCollisionDmg")
        {
            return;
        }
        if (collision.relativeVelocity.magnitude > wallDamageThreshold)
        {
            StartCoroutine("Invincible");
            TakeDamage((int)collision.impulse.magnitude);
        }
        //Note: If we need to apply damage only on specific objects use the tag
        //switch (collision.gameObject.tag)
        //{
        //    case "Wall":
        //        Debug.Log(name + "collided" + collision.relativeVelocity.magnitude);
        //        break;
        //    default:
        //        break;
        //}
    }

    private IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }


    public int getCurrentHealth() {
        return currentHealth;
    }

    public void setCurrentHealth(int current_health) {
        this.currentHealth = current_health;
    }
    private IEnumerator TakeFireDmgEverySecond(int dmg)
    {
        CR_TakeDmgIsRunning = true;
        while (bIsOnFire)
        {
            TakeDamage(dmg);

            yield return new WaitForSeconds(1);
        }
        CR_TakeDmgIsRunning = false;
    }

    public void setOlafOnFire()
    {
        bIsOnFire = true;

        if (!CR_TakeDmgIsRunning)
        {
            StartCoroutine(TakeFireDmgEverySecond(2));
        }
    }

    public void stopFireDamage()
    {
        bIsOnFire = false;
    }
}
