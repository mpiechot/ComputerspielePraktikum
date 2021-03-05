using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguMovement : MonoBehaviour
{
    Transform[] ArmsAndFeet = new Transform[4];
    
    
    //Strauchel Animation
    private Animator animator;
    string stateMoveFeet = "PenguFeet"; //Strauchel Animation beginnt
    string stateMoveForward = "PenguMoveForeward";
    string stateTurnAround = "turnAround";
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private float walkingLength = 4;
    [SerializeField]
    private bool moveFeet = false;
    [SerializeField]
    private bool floatsAround = false;
    [SerializeField]
    private bool walkBackAndForth = false;
    private bool bMoveForward = false;

    

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
        
        //start moving back and forth
        if(walkBackAndForth)
            StartCoroutine(moveBackAndForth(walkingLength));
        


    }

    // Update is called once per frame
    void Update()
    {
        if (moveFeet)
        {
            animator.Play(stateMoveFeet);
        }

        if (bMoveForward)
        {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        
        
        transform.Rotate(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0.0f, Space.Self);
        if (floatsAround)
        {
            transform.Rotate(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0.0f, Space.Self);
        }
    }

    

    public IEnumerator moveForward(float seconds)
    {
        animator.speed = 1; //to stop the animation with a 0 and resume here with the 1
        animator.Play(stateMoveForward);
        bMoveForward = true;
        yield return new WaitForSeconds(seconds);
        bMoveForward = false;
        animator.speed = 0;
        
    }

    private IEnumerator moveBackAndForth(float seconds)
    {
        while(walkBackAndForth)
        { 
            animator.speed = 1;
            animator.Play(stateMoveForward);
            bMoveForward = true;
            yield return new WaitForSeconds(seconds);
            bMoveForward = false;
            //to stop the animation
            animator.speed = 0;

            //turn around 180degres
            walkBackAndForth = false;
        }
    }


    private void getTransformOfLimbs()
    {
        ArmsAndFeet[0] = transform.Find("Arm1");
        ArmsAndFeet[1] = transform.Find("Arm2");
        ArmsAndFeet[2] = transform.Find("Feet1");
        ArmsAndFeet[3] = transform.Find("Feet1");
    }

}
