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
    [SerializeField]
    private ParticleSystem healingEffect;
    [SerializeField, Range(0, 300)]
    private float wallDamageThreshold;

    private bool invincible;
    private bool bIsOnFire = false;
    private bool CR_TakeDmgIsRunning = false;

    [HideInInspector]
    public List<int> collectedKeys = new List<int>();

    private GameObject FireFollowingOlaf;
    // Start is called before the first frame update
    void Start()
    {
        healingEffect.Stop();
        currentHealth = maxHealth;
        healthBar?.setMaxHealth(maxHealth);
        FireFollowingOlaf = GameObject.Find("FireFollowingOlaf");
        healOverTime(5);
    }

    public void TakeDamage(int dmg)
    {
        dmg = Mathf.Clamp(dmg, 0, maxDamage);
        int newHealth = currentHealth - dmg;

        setCurrentHealth(newHealth);
        
    }
    void Die()
    {
        Destroy(gameObject);
    }

    public void OnCollectKey(Key key)
    {
        collectedKeys.Add(key.id);
    }


    public void OnCollide(Collision collision)
    {
        if (!invincible)
        {
            CollisionHandling(collision);
        }
    }

    private void CollisionHandling(Collision collision)
    {
        if (collision.collider.tag == "NoCollisionDmg" || collision.collider.tag == "Player")
        {
            return;
        }
        
        if (collision.relativeVelocity.magnitude > wallDamageThreshold)
        {
            StartCoroutine("Invincible");
            FindObjectOfType<AudioManager>()?.PlayScream();
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

    internal void InitCollectedKeys(int[] collected_keyIDs)
    {
        GameManager gm = GameManager.Instance;
        for(int i = 0; i < collected_keyIDs.Length; i++)
        {
            int keyID = collected_keyIDs[i];
            gm.keys[keyID].CollectKey();
        }
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

    public void setCurrentHealth(int newHealth) {
        if (newHealth <= 0)
        {
            Die();
        }
        this.currentHealth = newHealth;
        healthBar?.setHealth(currentHealth);
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

    public void resetHealth(){
        Debug.Log("HELLO WORLD");
        healingEffect.Play();
        setCurrentHealth(maxHealth);
    }

    public void setOlafOnFire()
    {
        bIsOnFire = true;

        if (!CR_TakeDmgIsRunning)
        {
            StartCoroutine(TakeFireDmgEverySecond(1));
            
            if (FireFollowingOlaf != null)
            {
                //make Fire Particles follow Olaf
                FireFollowingOlaf.transform.parent = transform.Find("root").Find("spine").Find("brust");
                FireFollowingOlaf.transform.localPosition = new Vector3(0, 0, -0.03f);
                FireFollowingOlaf.transform.localScale = new Vector3(2, 2, 2);
                FireFollowingOlaf.transform.localRotation = Quaternion.Euler(-207,-177,57);
                
            }
        }
    }

    public void stopFireDamage()
    {
        bIsOnFire = false;
        FireFollowingOlaf.transform.parent = null;
        FireFollowingOlaf.transform.localScale = new Vector3(0, 0, 0);
    }

    public void healOverTime(float seconds)
    {
        StartCoroutine(healEveryHalfSecond(seconds));
    }

    private IEnumerator healEveryHalfSecond(float seconds)
    {
        float startTime = Time.time;
        ParticleSystem.MainModule main = healingEffect.main;
        main.loop = true;
        healingEffect.Play();
        while (Time.time - startTime < seconds)
        {
            if (currentHealth <= maxHealth)
                setCurrentHealth(Mathf.Min(currentHealth + 10,maxHealth));

            healthBar?.setHealth(currentHealth);
            Debug.Log("heealing " + getCurrentHealth());
            yield return new WaitForSeconds(0.5f);

        }
        main.loop = false;
        healingEffect.Stop();
    }
}
