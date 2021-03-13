using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOlafBumper : MonoBehaviour
{
    private bool bStop = false;
    private bool stoped = false;
    public GameObject olaf1;//testtest lul
    public GameObject olaf2;
    public GameObject olaf3;
    public GameObject olaf4;
    public GameObject olaf5;
    public GameObject olaf6;
    public GameObject olaf7;
    public GameObject olaf8;
    public GameObject olaf9;
    public GameObject olaf10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bStop)
        {
            olaf1.transform.parent.transform.Translate(new Vector3(30, 0, 0) * Time.deltaTime , Space.World);
            Debug.LogWarning("translation");

        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !stoped)
        {
            olaf1.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf2.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf3.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf4.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf5.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf6.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf7.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf8.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf9.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));
            olaf10.GetComponent<Rigidbody>().AddForce(new Vector3(100f, 0f, 0f));

            olaf1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf3.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf4.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf5.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf6.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf7.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf8.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf9.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            olaf10.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);


            // olaf1.transform.parent.transform.Translate(new Vector3(20, 0, 0), Space.World);
            StartCoroutine("stooopBitch");
            FindObjectOfType<Bumper2LongerReach>().stopBeingHit();
            stoped = true;
            Debug.LogWarning("TriggeredBumper");
        }


    }
    private IEnumerator stooopBitch()
    {
        Debug.LogWarning("Started");
        bStop = true;
        yield return new WaitForSeconds(0.2f);
        bStop = false;

    }
}
