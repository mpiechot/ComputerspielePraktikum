using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float speed = 6;

    private GameObject spring;
    private bool bPlayerHit = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        spring = transform.Find("Spring").gameObject;
        endPosition = spring.transform.position;
        spring.transform.Translate(new Vector3(0, 0 , transform.localScale.z *  3) , Space.Self) ;
        startPosition = spring.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bPlayerHit)
        {
            
            spring.transform.position = Vector3.Lerp(startPosition, endPosition, Time.deltaTime * speed);
            
            startPosition = spring.transform.position;
          
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit by: " + collision);
        if (collision.gameObject.tag == "Player")
            {
            bPlayerHit = true;
            //Make Player Freefloat after getting hit for 1 sec
            StartCoroutine(FindObjectOfType<GravityController>().LockGravityAndFreeFloat(3f));
        }
        
    }
}
