using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pengu : MonoBehaviour
{
    

    Transform[] ArmsAndFeet= new Transform[4];
    bool moveFeet = false;

    

    private Animator animator;
    string stateName = "PenguFeet";

    public Material m_Material;
    public Texture penguTex;
    public Texture penguTexBlinzeln;
    

    
    private bool CR_Running = false;
   

    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        m_Material.mainTexture = penguTex;
        // m_Material = GetComponent<Renderer>().material;
        //m_Material.SetTexture("_MainTex", penguTexBlinzeln);

        animator = GetComponent<Animator>();

        ArmsAndFeet[0] = transform.Find("Arm1");
        ArmsAndFeet[1] = transform.Find("Arm2");
        ArmsAndFeet[2] = transform.Find("Feet1");
        ArmsAndFeet[3] = transform.Find("Feet1");

        

        if (animator == null)
        {
            Debug.LogError("No Animator found on Pengu");
            return;
        }
        animator.Play(stateName);


        

    }

    // Update is called once per frame
    void Update()
    {
        if (!CR_Running)
        {
           StartCoroutine(blinzeln());
        }

        



       // FindObjectOfType<PenguSound>().playSounds("PenguScreamSoundClip" , 100);
        
            
        
        
    }

    IEnumerator blinzeln()
    {
        CR_Running = true;
        
        m_Material.mainTexture = penguTex;
        yield return new WaitForSeconds(4);
        m_Material.mainTexture = penguTexBlinzeln;
        yield return new WaitForSeconds(1);
        CR_Running = false;
    }
    void OnDestroy()
    {
        m_Material.mainTexture = penguTex;
    }
    }
