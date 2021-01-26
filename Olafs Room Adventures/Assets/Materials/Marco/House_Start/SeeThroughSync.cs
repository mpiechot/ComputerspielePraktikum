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

    public List<Material> WallMaterials;
    public LayerMask Mask;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {      
        WallMaterials.ForEach(mat => CheckMaterial(mat));       
    }
    private void CheckMaterial(Material mat)
    {
        var dir = cam.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask))
        {
            StopAllCoroutines();
            StartCoroutine("StartHiding",mat);
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine("StopHiding", mat);
        }

        var view = cam.WorldToViewportPoint(transform.position);
        mat.SetVector(PosID, view);
    }

    private IEnumerator StartHiding(Material mat)
    {
        mat.SetFloat("_Distance", (transform.position - cam.transform.position).magnitude);
        while(mat.GetFloat(SizeID) != size)
        {
            //Debug.Log("Hiding " + mat.name + "!");
            mat.SetFloat(SizeID, Mathf.Lerp(mat.GetFloat(SizeID), size, stepSize));
            yield return 0;
        }
    }
    private IEnumerator StopHiding(Material mat)
    {
        while (mat.GetFloat(SizeID) != 0)
        {
            mat.SetFloat(SizeID, Mathf.Lerp(mat.GetFloat(SizeID), 0, stepSize));
            yield return 0;
        }
    }
}
