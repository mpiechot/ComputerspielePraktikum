using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pengu : MonoBehaviour
{

    //soundAbspielen
    private event System.Action PlayScreamSound;
    
    //Blinzeln durch andere Texture
    public Material m_Material;
    public Texture penguTex;
    public Texture penguTexBlinzeln;

    PenguSound Sounds;
    private bool CR_Running = false;
    [SerializeField]
    private bool bBlinzeln = true;
    [SerializeField]
    private bool bPlayScreamSounds = true;

    // Start is called before the first frame update
    void Start()
    {
        //initialice standart texture
        m_Material.mainTexture = penguTex;
        //Find Script for Sounds to play Scream soudn
        Sounds = FindObjectOfType<PenguSound>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!CR_Running && bBlinzeln)
            StartCoroutine(blinzeln());
        
        if(bPlayScreamSounds)
            Sounds.playSounds("PenguScreamSoundClip" , 100);//play Scream
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
