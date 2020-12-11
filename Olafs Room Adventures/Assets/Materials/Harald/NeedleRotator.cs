using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleRotator : MonoBehaviour
{

    public Camera main_camera;

    private Vector3 NORTH = new Vector3(0,0,1f);

    

    // Update is called once per frame
    void Update()
    {


        //Get the motion direction of the player
        Vector3 camera_forward = main_camera.GetComponent<Transform>().forward;

        Vector3 line_intersection = lineIntersection(camera_forward,NORTH,new Vector3(0,0,0), NORTH);

        Vector3 to = line_intersection - camera_forward;

        // if(camera_forward.z < 0){
        //     transform.forward = Vector3.Normalize(camera_forward);
        // }
        // else{
        //     transform.forward = Vector3.Normalize(camera_forward + 2 * to);
        // }

        float t = (camera_forward.z + 1f)/2f;
        Vector3 v = Vector3.Normalize(camera_forward + 2 * to);
        float y = t * v.y + (1 - t) * -v.y;
        
        transform.forward = new Vector3(v.x,y,v.z);
        
        
        //transform.forward = t * Vector3.Normalize(camera_forward + 2 * to) + (1 - t) * -Vector3.Normalize(camera_forward + 2 * to);
        
        
        //transform.rotation = Quaternion.LookRotation(Vector3.Normalize(camera_forward + 2 * to));
    }

    public Vector3 lineIntersection(Vector3 planePoint, Vector3 planeNormal, Vector3 linePoint, Vector3 lineDirection) {
        float t = Vector3.Dot(planeNormal,planePoint) - Vector3.Dot(planeNormal,linePoint) / Vector3.Dot(planeNormal,lineDirection);
        return linePoint + lineDirection * t;
    }
}
