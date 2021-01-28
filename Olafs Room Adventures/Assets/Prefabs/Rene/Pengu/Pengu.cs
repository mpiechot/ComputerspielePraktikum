using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengu : MonoBehaviour
{
    Transform[] ArmsAndFeet= new Transform[4];
    bool moveFeet = false;

    private Animator animator;
    string stateName = "PenguFeet";


    
    private AudioSource PenguSource;
    public  AudioClip PenguSound;
    public float Volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        ArmsAndFeet[0] = transform.Find("Arm1");
        ArmsAndFeet[1] = transform.Find("Arm2");
        ArmsAndFeet[2] = transform.Find("Feet1");
        ArmsAndFeet[3] = transform.Find("Feet1");

        PenguSource = gameObject.AddComponent<AudioSource>();
        PenguSource.clip = PenguSound;
        PenguSource.playOnAwake = false;
        PenguSource.dopplerLevel = 1;
        PenguSource.volume = Volume;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0.0f, Space.Self);

        if (Input.anyKey)
        {
            moveFeet = true;
        }

        if (moveFeet)
        {
            if (animator == null)
            {
                Debug.LogError("No Animator found on Pengu");
                return;
            }
            animator.Play(stateName);


            if (PenguSource == null) 
            {
                Debug.LogError("No SoundSource on Pengu");
                return; 
            }
            if ( !PenguSource.isPlaying)
            {
                PenguSource.Play();
            }
        }
    }
}
