using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private AudioSource bellSoundSource;
    private AudioSource elevatorSoundSource;

    public AudioClip bell;
    public AudioClip elevatorSound;

    public float speed = 0.5f;

    private bool bOpenDoor = false;
    private GameObject Door;
    private GameObject[] leftRightDoor = new GameObject[2];

    private Vector3[] startPositionDoors = new Vector3[2];
    private Vector3[] endPositionDoors = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        
        //sound Set-up
        bellSoundSource = gameObject.AddComponent<AudioSource>();
        elevatorSoundSource = gameObject.AddComponent<AudioSource>();

        bellSoundSource.clip = bell;
        bellSoundSource.playOnAwake = false;
       

        elevatorSoundSource.clip = elevatorSound;
        elevatorSoundSource.playOnAwake = false;

        //Door set-up
        Door = transform.Find("Door").gameObject;
        leftRightDoor[0] = Door.transform.Find("LeftDoor").gameObject;
        leftRightDoor[1] = Door.transform.Find("RightDoor").gameObject;

        startPositionDoors[0] = leftRightDoor[0].transform.position;
        startPositionDoors[1] = leftRightDoor[1].transform.position;

        endPositionDoors[0] = (leftRightDoor[0].transform.position - 6 * Vector3.right);
        endPositionDoors[1] = (leftRightDoor[1].transform.position - 6 * Vector3.left);

        


    }

    // Update is called once per frame
    void Update()
    {
        

        if (bOpenDoor) 
        {
            if (!bellSoundSource.isPlaying && bell != null)  
                bellSoundSource.Play(); 

            leftRightDoor[0].transform.position = Vector3.Lerp(startPositionDoors[0], endPositionDoors[0], Time.deltaTime * speed);
            startPositionDoors[0] = leftRightDoor[0].transform.position;

            leftRightDoor[1].transform.position = Vector3.Lerp(startPositionDoors[1], endPositionDoors[1], Time.deltaTime * speed);
            startPositionDoors[1] = leftRightDoor[1].transform.position;
        }

        //dorr open
        if (Mathf.Abs(endPositionDoors[0].x - leftRightDoor[0].transform.position.x) < 1.0f)
            bOpenDoor = false; 
    }

    public void playSounds() 
    {
        if(!elevatorSoundSource.isPlaying)
            elevatorSoundSource.Play();
    }

    public void stopSounds()
    {
        if (elevatorSoundSource.isPlaying)
            elevatorSoundSource.Stop();
    }



    public void openDoor() 
    {
        bOpenDoor = true;
    }
}
