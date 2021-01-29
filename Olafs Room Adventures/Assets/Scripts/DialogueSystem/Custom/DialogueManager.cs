using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.Events;
using System.Globalization;

namespace DialogueSystem
{
    [System.Serializable] public class TextRevealEvent : UnityEvent<char> { }

    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText; // text in dialogueText box
        public TextMeshProUGUI nameText;

        public float letterSpeed;
        public TextRevealEvent onTextReveal;

        public Animator dialogueBoxAnimator;
        public Animator dialogueTextAnimator;
        public Animator dialogueContinueButtonAnimator;

        private bool continueDialogue;
        public bool activeCutscene;

        private Queue<string> sentences;
        
        void Start() 
        {
            sentences = new Queue<string>();
            dialogueText.maxVisibleCharacters = 0; // hide the text currently written in the dialogueText box
        }

        void Update() 
        {
            if (continueDialogue && !activeCutscene)
            {
                if (!dialogueContinueButtonAnimator.GetBool("sentenceFinished")) 
                {
                    dialogueContinueButtonAnimator.SetBool("sentenceFinished", true);
                }
                if (Input.GetKeyDown("space")) 
                {
                    DisplayNextSentence();
                }
            }
        }


        public void StartDialogue(Dialogue dialogue)
        {
            nameText.text = dialogue.name;
            dialogueBoxAnimator.SetBool("isOpen", true);
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
                
            }
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            continueDialogue = false;
            dialogueTextAnimator.SetBool("isShaking", false);
            dialogueContinueButtonAnimator.SetBool("sentenceFinished", false);

            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            // split the whole text into parts based off the <> tags 
            // even numbers in the array are text, odd numbers are tags
            string[] subTexts = sentence.Split('<', '>');

            string displaySentence = "";
            // textmeshpro still needs to parse its built-in tags, so we only include noncustom tags
            for (int i = 0; i < subTexts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    displaySentence += subTexts[i];
                }
                else if (!isCustomTag(subTexts[i]))
                {
                    displaySentence += $"<{subTexts[i]}>";
                }
            }

            bool isCustomTag(string tag) 
            {
                return tag.StartsWith("speed") || tag.StartsWith("pause") || tag.StartsWith("shake") || tag.StartsWith("stopshake");
            }

            dialogueText.maxVisibleCharacters = 0;
            dialogueText.text = displaySentence;
            
            StopAllCoroutines();
            StartCoroutine(Read());
        
            IEnumerator Read()
            {
                //dialogueText.ForceMeshUpdate();
                
                int subCounter = 0;
                int visibleCount = 0;

                while (subCounter < subTexts.Length)
                {
                    if (subCounter % 2 == 1)
                    {
                        yield return EvaluateTag(subTexts[subCounter]);
                    }
                    else 
                    {
                        while (visibleCount < subTexts[subCounter].Length)
                        { 
                            onTextReveal.Invoke(subTexts[subCounter][visibleCount]);
                            visibleCount++;
                            dialogueText.maxVisibleCharacters++;
                            
                            yield return new WaitForSeconds(1f / letterSpeed); 
                        }
                        visibleCount = 0;
                    }
                    subCounter++;
                }
                continueDialogue = true;
                yield return null;

                WaitForSeconds EvaluateTag(string tag) 
                {
                    if (tag.Length > 0)
                    {
                        if (tag.StartsWith("pause="))
                        {   
                            string pauseString = tag.Split('=')[1].Replace(',','.');
                            return new WaitForSeconds(float.Parse(pauseString, CultureInfo.InvariantCulture));
                        }
                        else if (tag.StartsWith("speed="))
                        {
                            letterSpeed = float.Parse(tag.Split('=')[1]);
                        }
                        else if (tag.StartsWith("shake"))
                        {
                            dialogueTextAnimator.SetBool("isShaking", true);
                        }
                        else if (tag.StartsWith("stopshake"))
                        {
                            dialogueTextAnimator.SetBool("isShaking", false);
                        }
                    }
                    return null;
                }

            }

        }

        public void EndDialogue()
        {
            dialogueBoxAnimator.SetBool("isOpen", false);
        }
        
    }
}

