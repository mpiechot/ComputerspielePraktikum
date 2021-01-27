using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueAudio : MonoBehaviour
    {
        public DialogueManager dialogueManager;

        [Space]
        public AudioClip[] voices;
        public AudioClip[] punctuations;

        [Space]
        public AudioSource voiceSource;
        public AudioSource punctuationSource;

        void Start() 
        {
            dialogueManager.onTextReveal.AddListener((newChar) => ReproduceSound(newChar));
        }

        public void ReproduceSound(char c) 
        {
            if (char.IsPunctuation(c) && !punctuationSource.isPlaying)
            {
                voiceSource.Stop();
                punctuationSource.clip = punctuations[Random.Range(0, punctuations.Length)];
                punctuationSource.Play();
            }

            if (char.IsLetter(c) && !voiceSource.isPlaying)
            {
                punctuationSource.Stop();
                voiceSource.clip = voices[Random.Range(0, voices.Length)];
                voiceSource.Play();
            }
        }
    }

}
