using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellBumperToStopBumping : MonoBehaviour
{
    private int position = 0;
    public event System.Action OnWallCollission;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnWallCollission();
            
            position += 1;

            //switch (position)
            //{
            //    case 0:
            //        Debug.Log("case0");
            //        break;
            //    case 1:
            //        transform.position += new Vector3(-40, 0, 0);
            //        Debug.Log("case1");
            //        break;
            //    case 2:
            //        transform.position += new Vector3(-10, 0, 40);
            //        Debug.Log("case1");
            //        break;
            //}
        }
    }
}
