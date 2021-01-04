using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySaver : MonoBehaviour
{
    private MeshCollider collider;
    private MeshRenderer renderer;
    private float onAlpha = 0.2f;

    private void Start()
    {
        collider = GetComponent<MeshCollider>();
        renderer = GetComponent<MeshRenderer>();
        onAlpha = renderer.material.color.a;
    }
    public void OnSwitchOnEvent()
    {
        collider.enabled = false;
        Color color = renderer.material.color;
        color.a = 0f;
        renderer.material.color = color;
    }
    public void OnSwitchOffEvent()
    {
        collider.enabled = true;
        Color color = renderer.material.color;
        color.a = onAlpha;
        renderer.material.color = color;
    }
}
