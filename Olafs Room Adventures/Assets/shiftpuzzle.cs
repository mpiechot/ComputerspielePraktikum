using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftpuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject cube1, cube2, cube3, cube4, cube5, cube6, cube7, cube8, cube9, cube10, cube11, cube12, cube13, cube14, cube15, cube0;


    //pieces wird position gewechselt
    //pcheck ist aktuelle position
    //psolution ist original /losung
    List<GameObject> pieces = new List<GameObject>();
    List<GameObject> pchecklist = new List<GameObject>();
    List<GameObject> psolutionlist = new List<GameObject>();
    private bool solved = false;
    Vector2 currentEmpty = new Vector2(0, 3);
    int newp;
    int currentp;
    Vector2 newv = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        MakeList();
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        //IsSolved();
        
        if (!solved)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("pressed L");
                Switch(2,15);
                Debug.Log("pressed L");
            }
            //Debug.Log("current  position is " + currentEmpty.x + "/" + currentEmpty.y);
            //Debug.Log("current  position  in list is " + WhichPlaceInList(currentEmpty));
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("pressed A");
                if (IsAllowed("left"))
                {
                    newv.x = currentEmpty.x;
                    newv.y = currentEmpty.y - 1;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                    Debug.Log("executed left");
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("pressed D");
                if (IsAllowed("right"))
                {
                    newv.x = currentEmpty.x;
                    newv.y = currentEmpty.y + 1;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                    Debug.Log("executed right");
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressed E");
                if (IsAllowed("up"))
                {
                    newv.x = currentEmpty.x - 1;
                    newv.y = currentEmpty.y;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                    Debug.Log("executed up");
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("pressed Q");
                if (IsAllowed("down"))
                {
                    newv.x = currentEmpty.x + 1;
                    newv.y = currentEmpty.y;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                    Debug.Log("executed down");
                }
            }
        }
    }

    private void MakeList()
    { 
        pieces.Add(cube1);
        pieces.Add(cube2);
        pieces.Add(cube3);
        pieces.Add(cube4);
        pieces.Add(cube5);
        pieces.Add(cube6);
        pieces.Add(cube7);
        pieces.Add(cube8);
        pieces.Add(cube9);
        pieces.Add(cube10);
        pieces.Add(cube11);
        pieces.Add(cube12);
        pieces.Add(cube13);
        pieces.Add(cube14);
        pieces.Add(cube15);
        pieces.Add(cube0);

        psolutionlist = pieces;
        pchecklist = pieces;
    }

    private void Shuffle()
    {
        int a;
        int b;
        for (int i = 0; i < 15; i++)
        {
            a = Random.Range(0,14);
            b = Random.Range(0,14);
            Switch(a, b);
        }

    }

    private void Switch(int a, int b)
    {
        Vector3 placeSwap;
        GameObject positionSwap;
        placeSwap = pieces[a].transform.position;
        pieces[a].transform.position = pieces[b].transform.position;
        pieces[b].transform.position = placeSwap;

        positionSwap = pchecklist[a];
        pchecklist[a] = pchecklist[b];
        pchecklist[b] = positionSwap;
    }

    private void IsSolved()
    {
        if(pieces == psolutionlist)
        {
            solved = true;
        }
        solved = false;
    }

    private bool IsAllowed(string direction)
    {
        if(direction == "left")
        {
            if(currentEmpty.y != 0)
            {
                return true;
            }
        }
        if (direction == "right")
        {
            if (currentEmpty.y != 3)
            {
                return true;
            }
        }
        if (direction == "up")
        {
            if (currentEmpty.x != 0)
            {
                return true;
            }
        }
        if (direction == "down")
        {
            if (currentEmpty.x != 3)
            {
                return true;
            }
        }
        return false;
    }

    private int WhichPlaceInList(Vector2 v)
    {
        if(v.x ==0 && v.y ==0)
        {
            return 0;
        }
        if (v.x == 0 && v.y == 1)
        {
            return 1;
        }
        if (v.x == 0 && v.y == 2)
        {
            return 2;
        }
        if (v.x == 0 && v.y == 3)
        {
            return 15;
        }
        if (v.x == 1 && v.y == 0)
        {
            return 3;
        }
        if (v.x == 1 && v.y == 1)
        {
            return 4;
        }
        if (v.x == 1 && v.y == 2)
        {
            return 5;
        }
        if (v.x == 1 && v.y == 3)
        {
            return 6;
        }
        if (v.x == 2 && v.y == 0)
        {
            return 7;
        }
        if (v.x == 2 && v.y == 1)
        {
            return 8;
        }
        if (v.x == 2 && v.y == 2)
        {
            return 9;
        }
        if (v.x == 3 && v.y == 3)
        {
            return 10;
        }
        if (v.x == 3 && v.y == 0)
        {
            return 11;
        }
        if (v.x == 3 && v.y == 1)
        {
            return 12;
        }
        if (v.x == 3 && v.y == 2)
        {
            return 13;
        }
        if (v.x == 3 && v.y == 3)
        {
            return 14;
        }
        return 110;
    }
}
