using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneMoveToTopView : MonoBehaviour
{
    private Animator animator;

    private bool FreelookCam = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if(FreelookCam)
            {
                animator.Play("TopViewCam");
                
            }
            else
            {
                animator.Play("FreelookCam");
                
            }
            FreelookCam = !FreelookCam;
        }
    }
}
