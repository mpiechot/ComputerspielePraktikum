using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguMovement : MonoBehaviour
{
    Transform[] ArmsAndFeet = new Transform[4];
    
    
    //Strauchel Animation
    private Animator animator;
    string stateMoveFeet = "PenguFeet"; //Strauchel Animation beginnt

    [SerializeField]
    private bool moveFeet = false;
    [SerializeField]
    private bool floatsAround = false;
    [SerializeField]
    private bool walkBackAndForth = false;


    // Start is called before the first frame update
    void Start()
    {
        getTransformOfLimbs();
        //get animator on Pengu
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No Animator found on Pengu");
            return;
        }
        //playAnimation from the state
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFeet)
        {
            animator.Play(stateMoveFeet);
        }


        if (floatsAround)
        {
            transform.Rotate(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0.0f, Space.Self);
        }
    }

    public void moveForeward()
    { 
        
    }
        


    private void getTransformOfLimbs()
    {
        ArmsAndFeet[0] = transform.Find("Arm1");
        ArmsAndFeet[1] = transform.Find("Arm2");
        ArmsAndFeet[2] = transform.Find("Feet1");
        ArmsAndFeet[3] = transform.Find("Feet1");
    }

}
