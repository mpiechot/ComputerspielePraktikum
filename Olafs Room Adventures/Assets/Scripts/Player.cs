using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
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
    [SerializeField, Range(0,300)]
    private float wallDamageThreshold;

    private bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0)
        {
            Die();
        }
        healthBar.setHealth(currentHealth);
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
            Debug.Log(name + "collided with " + collision.gameObject.name);
        }
    }

    private void CollisionHandling(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                if (collision.impulse.magnitude > wallDamageThreshold)
                {
                    StartCoroutine("Invincible");
                    TakeDamage((int)collision.impulse.magnitude);
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }
}
