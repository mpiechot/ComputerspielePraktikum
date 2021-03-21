using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutpuzzle : MonoBehaviour
{

    [SerializeField]
    private GameObject d1, d2, d3, d4, d5, d6;

    [SerializeField]
    private GameObject p1, p2, p3, p4, p5, p6;

    List<GameObject> donuts = new List<GameObject>();
    //holds original positions
    List<Vector3> positions = new List<Vector3>();
    //holds new starting positions
    List<GameObject> randomPositions = new List<GameObject>();

    bool solved = true;
    bool blue = false;
    bool green = true;
    bool w2 = false;
    bool black = false;
    bool w1 = false;
    bool red = false;

    // Start is called before the first frame update
    void Start()
    {
        makeLists();
        //shufflePositions();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(donuts[0].transform.position, positions[0]));
        //isSolved();
        Debug.Log((donuts[3].transform.position == positions[3]));
        Debug.Log(donuts[3].transform.position);
        donuts[1].transform.position = positions[1];
        Debug.Log((donuts[3].transform.position == positions[3]));
        Debug.Log(donuts[3].transform.position);
        Debug.Log(positions[3]);
        if (!solved)
        {
            clippIt();
        }
    }

    private void makeLists()
    {
        donuts.Add(d1);
        donuts.Add(d2);
        donuts.Add(d3);
        donuts.Add(d4);
        donuts.Add(d5);
        donuts.Add(d6);

        positions.Add(d1.transform.position);
        positions.Add(d2.transform.position);
        positions.Add(d3.transform.position);
        positions.Add(d4.transform.position);
        positions.Add(d5.transform.position);
        positions.Add(d6.transform.position);

        randomPositions.Add(p1);
        randomPositions.Add(p2);
        randomPositions.Add(p3);
        randomPositions.Add(p4);
        randomPositions.Add(p5);
        randomPositions.Add(p6);
    }

    private void shufflePositions()
    {
        int a;
        for (int i = randomPositions.Count-1; i > -1; i--)
        {
            a = Random.Range(0, i);
            donuts[i].transform.position = randomPositions[a].transform.position;
            randomPositions.Remove(randomPositions[a]); 
        }

    }

    private void isSolved()
    {
        bool sred = (donuts[5].transform.position == positions[5]);
        bool sblue = (donuts[4].transform.position == positions[4]);
        bool sgreen = (donuts[3].transform.position == positions[3]);
        bool sw1 = (donuts[2].transform.position == positions[2]);
        bool sw2 = (donuts[1].transform.position == positions[1]);
        bool sblack = (donuts[0].transform.position == positions[0]);

        if(sred && sblue && sgreen && sw1 && sw2 && sblack)
        {
            solved = true;
        }
    }

    private void clippIt()
    {
        red = (donuts[5].transform.position == positions[5]);
        blue = (donuts[4].transform.position == positions[4]);
        green = (donuts[3].transform.position == positions[3]);
        w1 = (donuts[2].transform.position == positions[2]);
        w2 = (donuts[1].transform.position == positions[1]);
        black = (donuts[0].transform.position == positions[0]);
        int distance = 9;

        if ((Vector3.Distance(donuts[1].transform.position, positions[1]) < distance) && !w2)
        {
            donuts[1].transform.position = positions[1];
            donuts[1].transform.rotation = randomPositions[1].transform.rotation;
            donuts[1].GetComponent<Rigidbody>().isKinematic = true;
        }

        if ((Vector3.Distance(donuts[3].transform.position, positions[3]) < distance) && !green)
        {
            donuts[3].transform.position = positions[3];
            donuts[3].transform.rotation = randomPositions[3].transform.rotation;
            donuts[3].GetComponent<Rigidbody>().isKinematic = true;
        }

        if ((Vector3.Distance(donuts[0].transform.position, positions[0]) < distance) && !black)
        {
            donuts[0].transform.position = positions[0];
            donuts[0].transform.rotation = randomPositions[0].transform.rotation;
            //donuts[0].GetComponent<Rigidbody>().useGravity = false;
            //donuts[0].GetComponent<Rigidbody>().freezeRotation = true;
            donuts[0].GetComponent<Rigidbody>().isKinematic = true;
        }

        //Debug.Log("before green");
        if (green)
        {
            //Debug.Log("after green");
            if ((Vector3.Distance(donuts[4].transform.position, positions[4]) < distance) && !blue)
            {
                donuts[4].transform.position = positions[4];
                donuts[4].transform.rotation = randomPositions[4].transform.rotation;
                donuts[4].GetComponent<Rigidbody>().isKinematic = true;
            }

            if (blue)
            {
                if ((Vector3.Distance(donuts[5].transform.position, positions[5]) < distance) && !red)
                {
                    donuts[5].transform.position = positions[5];
                    donuts[5].transform.rotation = randomPositions[5].transform.rotation;
                    donuts[5].GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        if (w2)
        {
            if ((Vector3.Distance(donuts[2].transform.position, positions[2]) < distance) && !w1)
            {
                donuts[2].transform.position = positions[2];
                donuts[2].transform.rotation = randomPositions[2].transform.rotation;
                donuts[2].GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}