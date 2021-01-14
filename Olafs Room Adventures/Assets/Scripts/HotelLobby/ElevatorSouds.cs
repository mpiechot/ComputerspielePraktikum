using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSouds : MonoBehaviour
{
    private AudioSource bellSoundSource;
    private AudioSource elevatorSoundSource;
    public AudioClip bell;
    public AudioClip elevatorSound;

    // Start is called before the first frame update
    void Start()
    {
        setUpSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setUpSound()
    {
        bellSoundSource = gameObject.AddComponent<AudioSource>();
        elevatorSoundSource = gameObject.AddComponent<AudioSource>();

        bellSoundSource.clip = bell;
        bellSoundSource.playOnAwake = false;


        elevatorSoundSource.clip = elevatorSound;
        elevatorSoundSource.playOnAwake = false;
    }

    public void playSounds()
    {
        if (!elevatorSoundSource.isPlaying)
            elevatorSoundSource.Play();
    }
    public void playBellSound()
    {
        if (!bellSoundSource.isPlaying)
            bellSoundSource.Play();
    }

    public void stopSounds()
    {
        if (elevatorSoundSource.isPlaying)
            elevatorSoundSource.Stop();
    }

}
