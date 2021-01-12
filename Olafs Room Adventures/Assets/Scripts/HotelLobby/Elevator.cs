using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ElevatorType { 
    
    MoveUp,
    MoveDown,
    MoveUpAndLoadAsync,
    MoveDownAndLoadAsync,
    DoorClosedAtStart
}

public class Elevator : MonoBehaviour
{
    private AudioSource bellSoundSource;
    private AudioSource elevatorSoundSource;

    public AudioClip bell;
    public AudioClip elevatorSound;

    private float DoorSpeed = 0.05f;
    public ElevatorType elevatorType;
    public float distance = 1f;
    public string SceneNameToLoad = "";

    private bool bDoorOpen;
    private GameObject Door;
    private GameObject[] leftRightDoor = new GameObject[2];

    private Vector3[] DoorsClosedPosition = new Vector3[2];
    private Vector3[] DoorsOpenPosition = new Vector3[2];

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
        
        

                

                //door is open/Closed after it moved to end Position:
        if (Mathf.Abs(DoorsOpenPosition[0].x - leftRightDoor[0].transform.position.x) < 1.0f)
            bDoorOpen = true;

        if (Mathf.Abs(DoorsClosedPosition[0].x - leftRightDoor[0].transform.position.x) < 1.0f)
            bDoorOpen = false;


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
        DoorsClosedPosition[0] = leftRightDoor[0].transform.position;
        DoorsClosedPosition[1] = leftRightDoor[1].transform.position;

        DoorsOpenPosition[0] = (leftRightDoor[0].transform.position - leftRightDoor[0].GetComponent<Renderer>().bounds.size.x * Vector3.right);
        DoorsOpenPosition[1] = (leftRightDoor[1].transform.position - leftRightDoor[0].GetComponent<Renderer>().bounds.size.x * Vector3.left);

        if (elevatorType == ElevatorType.DoorClosedAtStart)
        {    
            bDoorOpen = false;
        }
        else
        {
            leftRightDoor[0].transform.position = DoorsOpenPosition[0];
            leftRightDoor[1].transform.position = DoorsOpenPosition[1];
            bDoorOpen = true;

            DoorsClosedPosition[0].x += leftRightDoor[0].transform.localScale.x;
            DoorsClosedPosition[1].x -= leftRightDoor[1].transform.localScale.x;
        }

    }

    public void playSounds() 
    {
        if(!elevatorSoundSource.isPlaying)
            elevatorSoundSource.Play();
    }
    public void playBellSound()
    {
        if (!bellSoundSource.isPlaying)
            bellSoundSource.Play();
    }

    public void stopSounds()
    {
        if (elevatorSoundSource.isPlaying)
            elevatorSoundSource.Stop();
    }


    public IEnumerator openDoor()
    {
        

        while(bDoorOpen == false)
        {
            leftRightDoor[0].transform.position = Vector3.Lerp(leftRightDoor[0].transform.position, DoorsOpenPosition[0], Time.deltaTime * DoorSpeed);
            

            leftRightDoor[1].transform.position = Vector3.Lerp(leftRightDoor[1].transform.position, DoorsOpenPosition[1], Time.deltaTime * DoorSpeed);
            
            yield return 0;
        }

        


    }
    public IEnumerator closeDoor()
    {


        while (bDoorOpen == true)
        {
            leftRightDoor[0].transform.position = Vector3.Lerp(leftRightDoor[0].transform.position, DoorsClosedPosition[0], Time.deltaTime * DoorSpeed);
            

            leftRightDoor[1].transform.position = Vector3.Lerp(leftRightDoor[1].transform.position, DoorsClosedPosition[1], Time.deltaTime * DoorSpeed);
            
            yield return 0;
        }




    }


    public IEnumerator BeginHotelLevel()
    {
        playSounds();
        while (radio.playRadioLouder()) 
        {
            yield return 0;
        }
        gameManager.FadeIn();
        blackScreen.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        playBellSound();
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(openDoor());
        while (!radio.playRadioLouder())
        {
            yield return 0;
        }



    }

    public IEnumerator MoveUp()
    {
        openDoor();

        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        yield return 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                switch (elevatorType)
                {
                    case ElevatorType.DoorClosedAtStart:
                        StartCoroutine(BeginHotelLevel());
                    break;


                    case ElevatorType.MoveUp:
                    StartCoroutine(closeDoor());
                    break;
                }


        }
    }

   
}
