﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public GravityController gravityController;
    public CameraController CameraController;

    public GameObject gameManager;

    private Queue<string> sentences; // Queue is a FIFO collection

    public float letterDelay;

    private int fontSize = 20;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, float delay) 
    {
        gameManager.GetComponent<GravityController>().enabled = false;

        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        letterDelay = delay;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            string[] subTexts = sentence.Split('<', '>');
            Debug.Log(subTexts.Length);
            foreach(string s in subTexts) {
                Debug.Log("subTexts contents: " + s);
            }
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }

    public void EndDialogue()
    {
        gameManager.GetComponent<GravityController>().enabled = true;
        animator.SetBool("isOpen", false);
    }

}
