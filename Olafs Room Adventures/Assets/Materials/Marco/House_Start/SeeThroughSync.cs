using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    [SerializeField]
    private float size = 1;
    [SerializeField]
    private float stepSize = 0.3f;
    [SerializeField]
    private float offsetY = 2f;

    public Material WallMaterial;
    public LayerMask Mask;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var dir = cam.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if(Physics.Raycast(ray, 3000, Mask))
        {
            StopAllCoroutines();
            StartCoroutine("StartHiding");
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine("StopHiding");
        }

        var view = cam.WorldToViewportPoint(transform.position);
        view.y += offsetY;
        WallMaterial.SetVector(PosID, view);
    }

    private IEnumerator StartHiding()
    {
        while(WallMaterial.GetFloat(SizeID) != size)
        {
            Debug.Log("Hiding!");
            WallMaterial.SetFloat(SizeID, Mathf.Lerp(WallMaterial.GetFloat(SizeID), size, stepSize));
            yield return 0;
        }
    }
    private IEnumerator StopHiding()
    {
        while (WallMaterial.GetFloat(SizeID) != 0)
        {
            WallMaterial.SetFloat(SizeID, Mathf.Lerp(WallMaterial.GetFloat(SizeID), 0, stepSize));
            yield return 0;
        }
    }
}
