using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMP_Animated : MonoBehaviour
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
    public bool isWriting;

    void Awake() 
    {
        isWriting = true;
    }

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
        dialogueText.text = sentence;
        dialogueText.maxVisibleCharacters = 0;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        int subCounter = 0;
        int visibleCounter = 0;
        while (subCounter < dialogueText.text.Length)
        {
            visibleCounter++;
            dialogueText.maxVisibleCharacters++;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        gameManager.GetComponent<GravityController>().enabled = true;
        animator.SetBool("isOpen", false);
    }

}

