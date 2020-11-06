using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class WallHiding : MonoBehaviour
{
    public Camera cam;
    public Vector3 normal;
    public float hideFactor = 0.5f;

    [SerializeField]
    public Axis axis;

    private MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = rend.material.color;
        Debug.Log("CameraPos: " + GetAxisPosition(cam.transform));
        Debug.Log("TransformPos: " + GetAxisPosition(transform));
        if(Vector3.Dot(normal,cam.transform.forward) > 0 && GetAxisPosition(cam.transform) > GetAxisPosition(transform))
        {
            Debug.Log("Transparent");
            color.a = hideFactor;
        }
        else
        {
            Debug.Log("Solid");
            color.a = 1f;
        }
        rend.material.color = color;
    }

    private float GetAxisPosition(Transform transform)
    {
        switch (axis)
        {
            case Axis.X: return Mathf.Abs(transform.position.x);
            case Axis.Y: return Mathf.Abs(transform.position.y);
            case Axis.Z: return Mathf.Abs(transform.position.z);
        }
        return 0;
    }
}
