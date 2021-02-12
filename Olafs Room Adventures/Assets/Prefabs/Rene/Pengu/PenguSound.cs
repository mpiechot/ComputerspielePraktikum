using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PenguSound : MonoBehaviour
{
    private AudioSource PenguSource;
    public AudioClip PenguScreamSoundClip;
    Dictionary<string, AudioClip> PenguClips;
    
    [SerializeField]
    private float Volume = 0.2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initioateSoundSources();
        PenguClips = new Dictionary<string, AudioClip>();
        PenguClips.Add("PenguScreamSoundClip", PenguScreamSoundClip);

        indicateErrors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Name the (internal) name of the AudioClip like "PenguScreamSoundClip" to play that audio with a certain volume.
    public void playSounds(string ClipName, float volume)
    {
        
        PenguSource.volume = volume;
        //Get that AudioClip from Dictionary.
        PenguSource.clip = PenguClips[ClipName];
        
        
        //play sound
        if (!PenguSource.isPlaying)
              PenguSource.Play();
    }

    public void stopAllSounds()
    {
        PenguSource.Stop();
    }

    private void initioateSoundSources()
    {
        PenguSource = gameObject.AddComponent<AudioSource>();
        PenguSource.clip = PenguScreamSoundClip;
        PenguSource.playOnAwake = false;
        PenguSource.dopplerLevel = 0.1f;
        PenguSource.volume = Volume;
    }

    private void indicateErrors()
    {
        if (PenguSource == null)
        {
            Debug.LogError("No SoundSource on Pengu");
            return;
        }
    }
}
