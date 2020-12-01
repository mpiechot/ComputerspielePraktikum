using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSoundManager : MonoBehaviour
{
    public AudioSource radioSongSource;
    public AudioSource radioHitSoundSource;

    public AudioClip radioSong;
    public AudioClip radioHitSound;
    

    // Start is called before the first frame update
    void Start()
    {
        radioSongSource = gameObject.AddComponent<AudioSource>(); 
        radioHitSoundSource = gameObject.AddComponent<AudioSource>();

        radioSongSource.clip = radioSong;
        radioSongSource.playOnAwake = false;
        radioSongSource.dopplerLevel = 0;

        radioHitSoundSource.clip = radioHitSound;
        radioHitSoundSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!radioSongSource.isPlaying && radioSongSource != null)
        {
           radioSongSource.Play();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        radioHitSoundSource.Play();
    }

}
