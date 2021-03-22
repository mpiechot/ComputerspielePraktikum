using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private float speed = 2.2f;
    [SerializeField]
    public float Delay = 0f;
    [SerializeField]
    private Vector3 Direction = new Vector3(0,0,0);
    [SerializeField]
    public float magnitude = 1f;
    public GameObject olaf;
    private GameObject spring;
    private bool bPlayerHit = false;
    private bool bShootSpringHit = false;
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
        FindObjectOfType<TellBumperToStopBumping>().OnWallCollission += stopBeingHit;
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

            
            
            olaf.transform.Translate(Direction * Time.deltaTime * magnitude, Space.World);

        }
        
    }

    IEnumerator bumpAfterDelay()
    {
        CR_runnig = true;
        yield return new WaitForSeconds(Delay);
        lrpPrc = 0;
        bShootSpringHit = true;
        yield return new WaitForSeconds(0.5f);
        bPlayerHit = true;
        //olaf.transform.Translate((endPosition - startPosition) * 1.1f, Space.World);
        
        yield return new WaitForSeconds(2);
        lrpPrc = 0;
        bPlayerHit = false;
        bShootSpringHit = false;
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
    private void stopBeingHit()
    {
        bPlayerHit = false;
    }

}
