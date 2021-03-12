using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneStartSong : MonoBehaviour
{
    private AudioSource SoundSource;
    public AudioClip SynthSong;

    RadioSoundManager radioRene;
    // Start is called before the first frame update
    void Start()
    {
        radioRene = FindObjectOfType<RadioSoundManager>();
        SoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = SynthSong;
        SoundSource.playOnAwake = false;
    }

    public void playNewSong()
    {
        radioRene.stopPlaying();
        SoundSource.Play();
    }
}
