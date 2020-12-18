using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class WallTransparency : MonoBehaviour
{
    public Vector3 normal;
    public float hideFactor = 0.5f;
    public GameObject olaf_root;

    private MeshRenderer rend;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 line_intersection_point = lineIntersection(transform.position,normal,cam.transform.position,Vector3.Normalize(olaf_root.transform.position - cam.transform.position));
        Vector3 dir_intersection_to_cam = Vector3.Normalize(cam.transform.position - line_intersection_point);
        Vector3 dir_intersection_to_olaf_root = Vector3.Normalize(olaf_root.transform.position - line_intersection_point);

        Vector3 dif = dir_intersection_to_cam - dir_intersection_to_olaf_root;

        Color color = rend.material.color;
        if(Mathf.Abs(dif.x) < 0.05 && Mathf.Abs(dif.y) < 0.05 && Mathf.Abs(dif.x) < 0.05){
            color.a = 1f;
        }
        else{
            color.a = hideFactor;
        }
        rend.material.color = color;
    }

    public Vector3 lineIntersection(Vector3 planePoint, Vector3 planeNormal, Vector3 linePoint, Vector3 lineDirection) {
        float t = Vector3.Dot(planeNormal,planePoint) - Vector3.Dot(planeNormal,linePoint) / Vector3.Dot(planeNormal,lineDirection);
        return linePoint + lineDirection * t;
    }
}
