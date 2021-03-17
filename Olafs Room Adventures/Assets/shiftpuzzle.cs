using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftpuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject cube1, cube2, cube3, cube4, cube5, cube6, cube7, cube8, cube9, cube10, cube11, cube12, cube13, cube14, cube15, cube0;

    List<GameObject> pieces = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        MakeList();
        for (int i = 0; i < 15; i++)
        {
            Debug.Log(pieces[i]);
        }
        
        Shuffle();
        for (int i = 0; i < 15; i++)
        {
            Debug.Log(pieces[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    private void Shuffle()
    {
        int a;
        int b;
        for(int i = 0; i < 7; i++)
        {
            a = Random.Range(1,15);
            b = Random.Range(1,15);
            GameObject tet = pieces[a];
            pieces[a] = pieces[b];
            pieces[b] = tet;
        }

    }

}
