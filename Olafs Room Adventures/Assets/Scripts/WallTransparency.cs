using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class WallTransparency : MonoBehaviour
{
    public Vector3 normal;
    public float hideFactor = 0.5f;
    public GameObject olaf_root;
    public GameObject cam;

    private MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 line_intersection_point = lineIntersection(transform.position,normal,cam.transform.position,Vector3.Normalize(olaf_root.transform.position - cam.transform.position));
        // Vector3 dir_intersection_to_cam = Vector3.Normalize(cam.transform.position - line_intersection_point);
        // Vector3 dir_intersection_to_olaf_root = Vector3.Normalize(olaf_root.transform.position - line_intersection_point);

        // Vector3 dif = dir_intersection_to_cam - dir_intersection_to_olaf_root;

        // Color color = rend.material.color;
        // if(Mathf.Abs(dif.x) < 0.05 && Mathf.Abs(dif.y) < 0.05 && Mathf.Abs(dif.x) < 0.05){
        //     color.a = 1f;
        //     Debug.Log("hi");
        // }
        // else{
        //     color.a = hideFactor;
        // }
        // rend.material.color = color;




        // Color color = rend.material.color;
        // if(isWallBetweenSight(cam.transform.position,olaf_root.transform.position,transform.position,normal,0.005f)){
        //     color.a = 1f;
        // }
        // else{
        //     color.a = hideFactor;
        // }
        // rend.material.color = color;

        Color color = rend.material.color;
        float d0 = distancePointToPlane(cam.transform.position,transform.position,normal);
        float d1 = distancePointToPlane(olaf_root.transform.position,transform.position,normal);

        if(Mathf.Sign(d0) == Mathf.Sign(d1)){
            color.a = 1f;
        }
        else{
            color.a = hideFactor;
        }
        rend.material.color = color;
    }

    // public Vector3 lineIntersection(Vector3 planePoint, Vector3 planeNormal, Vector3 linePoint, Vector3 lineDirection) {
    //     float t = dot(planeNormal,planePoint) - (dot(planeNormal,linePoint) / dot(planeNormal,lineDirection));
    //     return linePoint + lineDirection * t;
    // }

    public float dot(Vector3 a, Vector3 b){
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    // public bool isWallBetweenSight(Vector3 line_point0,Vector3 line_point1,Vector3 plane_point,Vector3 plane_normal,float epsilon){
    //     Vector3 u = line_point1 - line_point0;
    //     float d = dot(plane_normal,u);

    //     if(Mathf.Abs(d) > epsilon){
    //         Vector3 w = line_point0 - plane_point;
    //         float fac = -dot(plane_normal,w)/d;
    //         return fac > 0 && fac < 1;
    //     }
    //     else{
    //         return false;
    //     }
    // }

    public float distancePointToPlane(Vector3 point, Vector3 plane_point, Vector3 plane_normal){
        return dot(plane_normal,(point - plane_point));
    }
}
