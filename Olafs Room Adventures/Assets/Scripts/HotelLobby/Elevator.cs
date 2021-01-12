using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ElevatorType { 
    DoorClosedAtStart,
    DoorOpenAtStart,
    MoveUp,
    MoveDown
}

public class Elevator : MonoBehaviour
{
    private AudioSource bellSoundSource;
    private AudioSource elevatorSoundSource;

    public AudioClip bell;
    public AudioClip elevatorSound;

    public float DoorSpeed = 0.5f;
    public ElevatorType elevatorType;


    private bool bDoorOpen;
    private GameObject Door;
    private GameObject[] leftRightDoor = new GameObject[2];

    private Vector3[] startPositionDoors = new Vector3[2];
    private Vector3[] endPositionDoors = new Vector3[2];

    private GameManager gameManager;
    private RadioSoundManager radio;
    public Transform blackScreen;

    // Start is called before the first frame update
    void Start()
    {

        //sound Set-up
        setUpSound();

        //Door set-up
        Door = transform.Find("Door").gameObject;
        leftRightDoor[0] = Door.transform.Find("LeftDoor").gameObject;
        leftRightDoor[1] = Door.transform.Find("RightDoor").gameObject;

        setUpDoorPositions();
        StartCoroutine(openCloseDoor());

        if (elevatorType == ElevatorType.DoorClosedAtStart)
        {
            gameManager =  FindObjectOfType<GameManager>();
            radio       =  FindObjectOfType<RadioSoundManager>();
            blackScreen = transform.Find("BlackScreen");
            blackScreen.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!bellSoundSource.isPlaying && bell != null)
        {
            bellSoundSource.Play();
        }

                

                //door is open/Closed after it moved to end Position:
        if (Mathf.Abs(endPositionDoors[0].x - leftRightDoor[0].transform.position.x) < 1.0f)
            bDoorOpen = (elevatorType == ElevatorType.DoorClosedAtStart) ? true : false;

        

    }



    private void setUpSound() 
    {
        bellSoundSource = gameObject.AddComponent<AudioSource>();
        elevatorSoundSource = gameObject.AddComponent<AudioSource>();

        bellSoundSource.clip = bell;
        bellSoundSource.playOnAwake = false;


        elevatorSoundSource.clip = elevatorSound;
        elevatorSoundSource.playOnAwake = false;
    }

    private void setUpDoorPositions() 
    {
        startPositionDoors[0] = leftRightDoor[0].transform.position;
        startPositionDoors[1] = leftRightDoor[1].transform.position;
        
        if (elevatorType == ElevatorType.DoorClosedAtStart)
        {
            endPositionDoors[0] = (leftRightDoor[0].transform.position - 6 * Vector3.right);
            endPositionDoors[1] = (leftRightDoor[1].transform.position - 6 * Vector3.left);
            bDoorOpen = false;
        }
        else
        {
            endPositionDoors[0] = (leftRightDoor[0].transform.position + 6 * Vector3.right);
            endPositionDoors[1] = (leftRightDoor[1].transform.position + 6 * Vector3.left);
            bDoorOpen = true;
        }

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


    public IEnumerator openCloseDoor()
    {

        while(bDoorOpen == false)
        {
            leftRightDoor[0].transform.position = Vector3.Lerp(startPositionDoors[0], endPositionDoors[0], Time.deltaTime * DoorSpeed);
            startPositionDoors[0] = leftRightDoor[0].transform.position;

            leftRightDoor[1].transform.position = Vector3.Lerp(startPositionDoors[1], endPositionDoors[1], Time.deltaTime * DoorSpeed);
            startPositionDoors[1] = leftRightDoor[1].transform.position;
            yield return 0;
        }
        Debug.Log("DoorOpen!");
        
    }


    public IEnumerator BeginHotelLevel()
    {
        while (radio.playRadioLouder()) 
        {
            yield return 0;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(BeginHotelLevel());
        }
    }

    public void openDoor() { }
}
