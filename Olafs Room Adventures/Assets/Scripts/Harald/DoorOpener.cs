using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    public void openDoor(){
        transform.GetChild(0).GetComponent<Animator>().Play("DoorOpen");
    }

    // public GameObject olaf;
    // public GameObject[] doors;

    // public float distance_threshold;
    // private bool[] doors_state; //false = close
    // private bool[] keys_collected;

    // void Start(){
    //     doors_state = new bool[doors.Length];
    //     keys_collected = new bool[doors.Length];
    // }

    // void Update(){
    //     for(int i = 0; i < doors.Length; i++){
    //         //if(i == 0) Debug.Log(distance(olaf.transform.position,doors[i].transform.position));
    //         if(distance(olaf.transform.position,doors[i].transform.position) < distance_threshold && !doors_state[i] && keys_collected[i]){
    //             // prevent reopening
    //             doors_state[i] = true;

    //             // start animation of the respective door
    //             Animator anim = doors[i].transform.GetChild(0).GetComponent<Animator>();
    //             anim.Play("DoorOpen");
    //         }
    //     }
    // }

    // float distance(Vector3 pos0, Vector3 pos1){
    //     return (pos0 - pos1).magnitude;
    // }

    // public void collectKey(int id){
    //     keys_collected[id] = true;
    // }
}
