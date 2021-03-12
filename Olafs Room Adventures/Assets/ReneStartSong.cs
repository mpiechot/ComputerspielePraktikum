using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneStartSong : MonoBehaviour
{
    RadioSoundManager radioRene;
    // Start is called before the first frame update
    void Start()
    {
        radioRene = FindObjectOfType<RadioSoundManager>();
    }

    public void playNewSong()
    {
        radioRene.stopPlaying();
    }
}
