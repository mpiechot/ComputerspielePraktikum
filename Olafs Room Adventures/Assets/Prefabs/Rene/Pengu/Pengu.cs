using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengu : MonoBehaviour
{
    Transform[] ArmsAndFeet= new Transform[4];
    bool moveFeet = false;

    private Animator animator;
    string stateName = "PenguFeet";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        ArmsAndFeet[0] = transform.Find("Arm1");
        ArmsAndFeet[1] = transform.Find("Arm2");
        ArmsAndFeet[2] = transform.Find("Feet1");
        ArmsAndFeet[3] = transform.Find("Feet1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            moveFeet = true;
        }

        if (moveFeet)
        {
            animator.Play(stateName);
        }
    }
}
