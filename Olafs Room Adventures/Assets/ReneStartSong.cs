using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneStartSong : MonoBehaviour
{
    private AudioSource SoundSource;
    public AudioClip SynthSong;
    private AudioSource GuitarSoundSource;
    public AudioClip GuitarSong;
    private bool bFade = false;
    float fatespeed = 10.0f;

    RadioSoundManager radioRene;
    // Start is called before the first frame update
    void Start()
    {
        radioRene = FindObjectOfType<RadioSoundManager>();
        SoundSource = gameObject.AddComponent<AudioSource>();
        GuitarSoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = SynthSong;
        SoundSource.playOnAwake = false;
        GuitarSoundSource.clip = GuitarSong;
        SoundSource.playOnAwake = false;
        GuitarSoundSource.volume = 1;
    }

    public void playNewSong()
    {
        radioRene.stopPlaying();
        SoundSource.Play();
    }
    public void playGuitar()
    {
        GuitarSoundSource.Play();
        Debug.Log("playGuit");
    }


    private void Update()
    {
        if (bFade)
        {

            SoundSource.volume = Mathf.Lerp(SoundSource.volume, 0, Time.deltaTime);
            
            
            if (SoundSource.volume < 0.01)
            {
                bFade = false;
            }
        }
    }

    public void FadeOut()
    {
        bFade = true;
    }
}
