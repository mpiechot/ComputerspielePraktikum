using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutpuzzle : MonoBehaviour
{

    [SerializeField]
    private GameObject d1, d2, d3, d4, d5, d6;

    [SerializeField]
    private GameObject p1, p2, p3, p4, p5, p6;

    [SerializeField]
    private GameObject c1, c2, c3, c4, c5, c6, bars;

    List<GameObject> donuts = new List<GameObject>();
    //holds original positions
    List<Vector3> positions = new List<Vector3>();
    //holds new starting positions
    List<GameObject> randomPositions = new List<GameObject>();

    bool solved = false;
    bool blue = false;
    bool green = false;
    bool w2 = false;
    bool black = false;
    bool w1 = false;
    bool red = false;

    // Start is called before the first frame update
    void Start()
    {
        makeLists();
        shufflePositions();
    }

    // Update is called once per frame
    void Update()
    {
        isSolved();
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

        positions.Add(c1.transform.position);
        positions.Add(c2.transform.position);
        positions.Add(c3.transform.position);
        positions.Add(c4.transform.position);
        positions.Add(c5.transform.position);
        positions.Add(c6.transform.position);


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
        double errorMargin = 0.0001;
        bool sred = (Vector3.Distance(donuts[5].transform.position, positions[5]) < errorMargin);
        bool sblue = (Vector3.Distance(donuts[4].transform.position, positions[4]) < errorMargin);
        bool sgreen = (Vector3.Distance(donuts[3].transform.position, positions[3]) < errorMargin);
        bool sw1 = (Vector3.Distance(donuts[2].transform.position, positions[2]) < errorMargin);
        bool sw2 = (Vector3.Distance(donuts[1].transform.position, positions[1]) < errorMargin);
        bool sblack = (Vector3.Distance(donuts[0].transform.position, positions[0]) < errorMargin);

        if (sred && sblue && sgreen && sw1 && sw2 && sblack)
        {
            solved = true;
            bars.SetActive(false);
        }
    }

    private void clippIt()
    {
        double errorMargin = 0.0001;
        red = (Vector3.Distance(donuts[5].transform.position, positions[5]) < errorMargin);
        blue = (Vector3.Distance(donuts[4].transform.position, positions[4]) < errorMargin);
        green = (Vector3.Distance(donuts[3].transform.position, positions[3]) < errorMargin);
        w1 = (Vector3.Distance(donuts[2].transform.position, positions[2]) < errorMargin);
        w2 = (Vector3.Distance(donuts[1].transform.position, positions[1]) < errorMargin);
        black = (Vector3.Distance(donuts[0].transform.position, positions[0]) < errorMargin);
        int distance = 9;
        //Debug.Log("red is: " + red + "\n" + "blue is: " + blue + "\n" +"Green is: "+ green + "\n" + "w1 is: "+ w1 + "\n" + "w2 is: " + w2 + "\n" + "black is: " + black);

        if ((Vector3.Distance(donuts[1].transform.position, positions[1]) < distance) && !w2)
        {
            donuts[1].transform.position = positions[1];
            donuts[1].transform.rotation = c1.transform.rotation;
            donuts[1].GetComponent<Rigidbody>().isKinematic = true;
        }

        if ((Vector3.Distance(donuts[3].transform.position, positions[3]) < distance) && !green)
        {
            donuts[3].transform.position = positions[3];
            donuts[3].transform.rotation = c1.transform.rotation;
            donuts[3].GetComponent<Rigidbody>().isKinematic = true;
        }

        //Debug.Log(Vector3.Distance(donuts[0].transform.position, positions[0]));
        //Debug.Log(black);
        if ((Vector3.Distance(donuts[0].transform.position, positions[0]) < distance) && !black)
        {
            donuts[0].transform.rotation = c1.transform.rotation;
            donuts[0].transform.position = positions[0];
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
                donuts[4].transform.rotation = c1.transform.rotation;
                donuts[4].GetComponent<Rigidbody>().isKinematic = true;
            }

            if (blue)
            {
                if ((Vector3.Distance(donuts[5].transform.position, positions[5]) < distance) && !red)
                {
                    donuts[5].transform.position = positions[5];
                    donuts[5].transform.rotation = c1.transform.rotation;
                    donuts[5].GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        if (w2)
        {
            if ((Vector3.Distance(donuts[2].transform.position, positions[2]) < distance) && !w1)
            {
                donuts[2].transform.position = positions[2];
                donuts[2].transform.rotation = c1.transform.rotation;
                donuts[2].GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}