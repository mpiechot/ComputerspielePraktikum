using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachBodyparts : MonoBehaviour
{

    public int lives;

    void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            test();
        }
    }

    private void test() 
    {
        switch (lives) 
        {
            case 5:
                Debug.Log("5 lives");
                break;
            case 4:
                Debug.Log("4 lives");
                break;
            case 3:
                Debug.Log("3 lives");
                break;
            case 2:
                Debug.Log("2 lives");
                break;
            case 1: 
                Debug.Log("1 life");
                break;
            default:
                Debug.Log("0 lives");
                break;
        }
    }
}
