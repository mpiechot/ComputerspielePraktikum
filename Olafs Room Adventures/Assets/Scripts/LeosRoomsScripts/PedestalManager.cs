using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public static int activatedPedestals;

    public int numberOfPedestals;
    public GameObject door;

    private bool levelFinished = false;

    void Start()
    {
        activatedPedestals = 0;
    }

    void Update()
    {
        if (!levelFinished && activatedPedestals == numberOfPedestals) {
            Debug.Log("You made it - took you long enough.");
            levelFinished = true;
            Animator doorAnimator = door.GetComponent<Animator>();
            doorAnimator.SetBool("pedestalsOccupied", true);
        }
    }
}
