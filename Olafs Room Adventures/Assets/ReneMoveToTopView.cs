using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneMoveToTopView : MonoBehaviour
{
    
    private Animator animator;
    [SerializeField]
    private bool ChangeViewToTopCam = true;
    private bool changed = false;
    private bool FreelookCam = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    public void SwitchCam()
    {
        
            if (FreelookCam)
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
