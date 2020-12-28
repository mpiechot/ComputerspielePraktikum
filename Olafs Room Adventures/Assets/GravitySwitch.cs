using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravitySwitch : MonoBehaviour
{
    [SerializeField]
    private Axis gravityDirection;
    [SerializeField,Range(0,10f)]
    private float GravityThreshold = 5f;

    [SerializeField]
    private UnityEvent SwitchOnEvent;
    [SerializeField]
    private UnityEvent SwitchOffEvent;

    private Animator anim;
    private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Actual Gravity: " + Physics.gravity);
        if (NeedToSwitchStates())
        {
            state = !state;
            anim.SetBool("SwitchOn", state);
            if (state)
            {
                SwitchOnEvent.Invoke();
            }
            else
            {
                SwitchOffEvent.Invoke();
            }
        }
    }

    private bool NeedToSwitchStates()
    {
        switch (gravityDirection)
        {
            case Axis.X: return CheckGravity(Physics.gravity.x);
            case Axis.Y: return CheckGravity(Physics.gravity.y);
            case Axis.Z: return CheckGravity(Physics.gravity.z);
            default: return false;
        }
    }
    private bool CheckGravity(float gravityAxisValue)
    {
        if(state && gravityAxisValue < -GravityThreshold)
        {
            return true;
        }
        if(!state && gravityAxisValue > GravityThreshold)
        {
            return true;
        }
        return false;
    }
}
