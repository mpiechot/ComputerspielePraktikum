using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int collectedKeys = 0;
    [SerializeField]
    private TextMeshProUGUI keysText;

    private static GameManager gm;
    public static GameManager Instance { get { return gm;} }
    public bool PlayerHasKeys { get { return collectedKeys > 0; } }

    private void Awake()
    {
        if(gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
        }
    }

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
    public void OnUseKey()
    {
        collectedKeys--;
        keysText.text = collectedKeys + "";
    }

}
