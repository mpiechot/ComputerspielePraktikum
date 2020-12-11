using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachBodyparts : MonoBehaviour
{

    public int lives;

    public GameObject leftLeg;
    public GameObject rightLeg;

    void Update()
    {
        if (Input.GetKeyDown("space")) // simuliert vorläufig, dass Olaf durch irgendetwas Schaden nimmt
        {
            lives--;
        }

        test();
    }



    private void test() 
    {
        switch (lives) 
        {
            case 0:
            Debug.Log("Game over");
                break;
            case 4:
                Destroy(rightLeg.GetComponent<CharacterJoint>());
                rightLeg.transform.parent = null;
                break;
            case 3:
                break;
            case 2:
                break;
            case 1: 
                break;
            default:
                break;
        }
    }
}
