using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText; // text in dialogueText box
        public TextMeshProUGUI nameText;

        public float letterSpeed;
        public Animator dialogueBoxAnimator;

        private Queue<string> sentences;
        
        private void Start() 
        {
            sentences = new Queue<string>();
            dialogueText.maxVisibleCharacters = 0; // hide the text currently written in the dialogueText box
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
                return tag.StartsWith("speed") || tag.StartsWith("pause");
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
                            visibleCount++;
                            dialogueText.maxVisibleCharacters++;
                            
                            yield return new WaitForSeconds(1f / letterSpeed); 
                        }
                        visibleCount=0;
                    }
                    subCounter++;
                }

                WaitForSeconds EvaluateTag(string tag) 
                {
                    if (tag.Length > 0)
                    {
                        if (tag.StartsWith("pause="))
                        {
                            return new WaitForSeconds(float.Parse(tag.Split('=')[1]));
                        }
                        else if (tag.StartsWith("speed="))
                        {
                            letterSpeed = float.Parse(tag.Split('=')[1]);
                        }
                        Debug.Log("Tag:" + tag);
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

