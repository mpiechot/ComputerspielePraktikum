using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private float speed = 3f;
    [SerializeField]
    public float Delay = 0f;
    public GameObject olaf;
    private GameObject spring;
    private bool bPlayerHit = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool CR_runnig = false;
    float lrpPrc = 0;


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

            spring.transform.position = Vector3.Lerp(startPosition, endPosition, lrpPrc);
            lrpPrc += Time.deltaTime * speed;
            
            olaf.transform.Translate((endPosition - startPosition) * Time.deltaTime * 0.5f, Space.World);

        }
        else
        {
           
            spring.transform.position = Vector3.Lerp(endPosition, startPosition, lrpPrc);
            lrpPrc += Time.deltaTime * speed;
        }
    }

    IEnumerator bumpAfterDelay()
    {
        CR_runnig = true;
        yield return new WaitForSeconds(Delay);
        lrpPrc = 0;
        bPlayerHit = true;
        olaf.transform.Translate((endPosition - startPosition) * 0.5f, Space.World);
        //Make Player Freefloat after getting hit for 1 sec
        StartCoroutine(FindObjectOfType<GravityController>().LockGravityAndFreeFloat(3f));
        yield return new WaitForSeconds(3);
        lrpPrc = 0;
        bPlayerHit = false;
        yield return new WaitForSeconds(3);
        CR_runnig = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player" && !CR_runnig)
        {
            StartCoroutine(bumpAfterDelay());
        }
        
    }

    
}
