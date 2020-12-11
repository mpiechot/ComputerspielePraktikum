using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int collectedKeys = 0;
    [SerializeField]
    private TextMeshProUGUI keysText;

    //public static GameManager instance;

    //public static GameManager GetGM()
    //{
    //    if(instance == null)
    //    {
    //        instance = new GameManager();
    //    }
    //    return instance;
    //}

    public Animator animator;

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    public void OnCollectKey()
    {
        collectedKeys++;
        keysText.text = collectedKeys+"";
    }
}
