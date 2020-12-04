using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSoundManager : MonoBehaviour
{
    private AudioSource radioSongSource;
    private AudioSource radioHitSoundSource;

    public AudioClip radioSong;
    public AudioClip radioHitSound;
    public float startVolume = 0;
    private bool bPlayOnRepeat = false;

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
        radioSongSource.volume = startVolume;

    }

    // Update is called once per frame
    void Update()
    {
        if (bPlayOnRepeat && !radioSongSource.isPlaying && radioSongSource != null)
        {
            radioSongSource.Play();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        radioHitSoundSource.Play();
    }

    public void startPlaying() 
    {
        bPlayOnRepeat = true;
    }

    public void setVolume(float volume) 
    {
        radioSongSource.volume = volume;
    }
}
