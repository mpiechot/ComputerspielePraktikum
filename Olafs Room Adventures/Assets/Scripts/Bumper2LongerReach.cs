using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper2LongerReach : MonoBehaviour
{
    private float speed = 1f;
    private float speedOlaf = 5f;
    [SerializeField]
    public float Delay = 0f;
    public GameObject olaf; //olaf butt because of rigitbody
    private GameObject spring;
    private bool bPlayerHit = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 Directions;
    private bool CR_runnig = false;
    float lrpPrc = 0;
    private bool bShootSpringHit = false;


    // Start is called before the first frame update
    void Start()
    {
        spring = transform.Find("Spring").gameObject;
        endPosition = spring.transform.position;
        spring.transform.Translate(new Vector3(0, 0, transform.localScale.z * 6), Space.Self);
        startPosition = spring.transform.position;
        Directions = (endPosition - startPosition).normalized;
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bShootSpringHit)
        {
            spring.transform.position = Vector3.Lerp(startPosition, endPosition, lrpPrc);
            lrpPrc += Time.deltaTime * speed;
        }
        else
        {

            spring.transform.position = Vector3.Lerp(endPosition, startPosition, lrpPrc);
            lrpPrc += Time.deltaTime * speed;
        }

        if (bPlayerHit)
        {

            

            olaf.transform.Translate((endPosition - startPosition) * 4.5f * Time.deltaTime , Space.World);
            
        }
        
        
    }
    public void stopBeingHit()
    {
        bPlayerHit = false;
    }
    IEnumerator bumpAfterDelay()
    {
        CR_runnig = true;
        yield return new WaitForSeconds(Delay);
        lrpPrc = 0;
        bShootSpringHit = true;
        yield return new WaitForSeconds(0.4f);
        bPlayerHit = true;

        //olaf.transform.Translate(new Vector3(1, 0, 0), Space.World);
        olaf.transform.Translate((endPosition - startPosition) * 0.05f, Space.World);
        // olaf.transform.position = olaf.transform.position + new Vector3(1, 0, 0);
        //translate root
        //olaf.transform.parent.transform.parent.transform.Translate(new Vector3(10, 0, 0) , Space.World);

        //olaf.transform.parent.transform.parent.transform.Translate((endPosition - startPosition) , Space.World);
        //Make Player Freefloat after getting hit for 1 sec
        //StartCoroutine(FindObjectOfType<GravityController>().LockGravityAndFreeFloat(2f));
        yield return new WaitForSeconds(2f);
        lrpPrc = 0;
        bPlayerHit = false;
        bShootSpringHit = false;
        yield return new WaitForSeconds(3);
        CR_runnig = false;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !CR_runnig)
        {
            StartCoroutine(bumpAfterDelay());
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NoCollisionDmg")
        {
            bPlayerHit = false;
        }
    }


}
