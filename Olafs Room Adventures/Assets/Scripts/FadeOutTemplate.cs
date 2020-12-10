
using UnityEngine;

public class FadeOutTemplate : MonoBehaviour
{
    public Animator animator;

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }
}
