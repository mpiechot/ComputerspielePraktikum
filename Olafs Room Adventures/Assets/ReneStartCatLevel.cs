using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneStartCatLevel : MonoBehaviour
{
    private AudioSource SoundSource;
    public AudioClip TrailerSound;
    // Start is called before the first frame update
    void Start()
    {
        
        SoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = TrailerSound;
        SoundSource.playOnAwake = false;

        SoundSource.Play();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
