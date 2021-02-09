using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private UnityEvent SwitchOnEvent;
    [SerializeField]
    private UnityEvent SwitchOffEvent;

    private Animator anim;
    [SerializeField]
    private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void SwitchOn()
    {
        state = true;
        anim.SetBool("SwitchOn", state);
        SwitchOnEvent.Invoke();
    }
    public void SwitchOff()
    {
        state = false;
        anim.SetBool("SwitchOn", state);
        SwitchOffEvent.Invoke();
    }
}
