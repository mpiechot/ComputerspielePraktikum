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
    private float startTime = 0f;
    private bool bPlayOnRepeat = false;
    private float lerpTime = 10;
    private float percentageComplete = 0;

    // Start is called before the first frame update
    void Start()
    {
        radioSongSource = gameObject.AddComponent<AudioSource>(); 
        radioHitSoundSource = gameObject.AddComponent<AudioSource>();

        radioSongSource.clip = radioSong;
        radioSongSource.playOnAwake = false;
        radioSongSource.dopplerLevel = 0.5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && radioHitSoundSource.isPlaying == false)
        {
            radioHitSoundSource.Play();
        }
        
    }

    public void startPlaying() 
    {

        bPlayOnRepeat = true;
    }

    public void stopPlaying()
    {

        bPlayOnRepeat = false;
        radioSongSource.Stop();

    }

    public void setVolume(float volume) 
    {
        radioSongSource.volume = volume;
    }

    public bool playRadioLouder()
    {
        
        if (startTime == 0)
        {
            startTime = Time.time;
            startPlaying();
        }
        
        float timeSinceStarted = Time.time - startTime;
        float percentageComplete = timeSinceStarted / lerpTime;

        setVolume(Mathf.Lerp(0, 1, percentageComplete));

        //true again when over 80% done
        if (percentageComplete > 0.6f) { return true; }
        //false when over 50% done.
        if (percentageComplete > 0.3f) { return false; }
        return true;
        
    }
}
