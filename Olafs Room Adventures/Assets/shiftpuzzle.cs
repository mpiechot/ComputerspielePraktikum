using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftpuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject cube1, cube2, cube3, cube4, cube5, cube6, cube7, cube8, cube9, cube10, cube11, cube12, cube13, cube14, cube15, cube0;


    //pieces wird position gewechselt
    //psolution ist original /losung
    List<GameObject> pieces = new List<GameObject>();
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
        //Debug.Log("pieces is: " + pieces[0].name + pieces[1].name + pieces[2].name + pieces[3].name + pieces[4].name + pieces[5].name + pieces[6].name + pieces[7].name + pieces[8].name + pieces[9].name + pieces[10].name + pieces[11].name + pieces[12].name + pieces[13].name + pieces[14].name + pieces[15].name );
        //Debug.Log("pchecklist is: " + pchecklist[0].name + pchecklist[1].name + pchecklist[2].name + pchecklist[3].name + pchecklist[4].name + pchecklist[5].name + pchecklist[6].name + pchecklist[7].name + pchecklist[8].name + pchecklist[9].name + pchecklist[10].name + pchecklist[11].name + pchecklist[12].name + pchecklist[13].name + pchecklist[14].name + pchecklist[15].name);
        //Debug.Log("psolutionlist is: " + psolutionlist[0].name + psolutionlist[1].name + psolutionlist[2].name + psolutionlist[3].name + psolutionlist[4].name + psolutionlist[5].name + psolutionlist[6].name + psolutionlist[7].name + psolutionlist[8].name + psolutionlist[9].name + psolutionlist[10].name + psolutionlist[11].name + psolutionlist[12].name + psolutionlist[13].name + psolutionlist[14].name + psolutionlist[15].name);
    }

    // Update is called once per frame
    void Update()
    {
        IsSolved();

        if (!solved)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (IsAllowed("left"))
                {
                    newv.x = currentEmpty.x;
                    newv.y = currentEmpty.y - 1;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (IsAllowed("right"))
                {
                    newv.x = currentEmpty.x;
                    newv.y = currentEmpty.y + 1;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (IsAllowed("up"))
                {
                    newv.x = currentEmpty.x - 1;
                    newv.y = currentEmpty.y;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (IsAllowed("down"))
                {
                    newv.x = currentEmpty.x + 1;
                    newv.y = currentEmpty.y;
                    newp = WhichPlaceInList(newv);
                    currentp = WhichPlaceInList(currentEmpty);
                    currentEmpty = newv;
                    Switch(newp, currentp);
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

        psolutionlist.Add(cube1);
        psolutionlist.Add(cube2);
        psolutionlist.Add(cube3);
        psolutionlist.Add(cube4);
        psolutionlist.Add(cube5);
        psolutionlist.Add(cube6);
        psolutionlist.Add(cube7);
        psolutionlist.Add(cube8);
        psolutionlist.Add(cube9);
        psolutionlist.Add(cube10);
        psolutionlist.Add(cube11);
        psolutionlist.Add(cube12);
        psolutionlist.Add(cube13);
        psolutionlist.Add(cube14);
        psolutionlist.Add(cube15);
        psolutionlist.Add(cube0);
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
        GameObject swapper;
        placeSwap = pieces[a].transform.position;
        pieces[a].transform.position = pieces[b].transform.position;
        pieces[b].transform.position = placeSwap;

        swapper = pieces[a];
        pieces[a] = pieces[b];
        pieces[b] = swapper;
    }

    private void IsSolved()
    {
        if(pieces == psolutionlist)
        {
            solved = true;
        }
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
        if (v.x == 2 && v.y == 3)
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
