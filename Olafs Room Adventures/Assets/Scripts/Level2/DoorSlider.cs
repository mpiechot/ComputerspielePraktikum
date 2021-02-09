using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlider : MonoBehaviour
{
    [SerializeField]
    private bool open;
    [SerializeField]
    private Vector3 openPosition;
    [SerializeField]
    private Vector3 closedPosition;
    [SerializeField]
    private float openSpeed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, openSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, openSpeed);
        }
    }
    public void Open()
    {
        open = true;
    }
    public void Close()
    {
        open = false;
    }
}
