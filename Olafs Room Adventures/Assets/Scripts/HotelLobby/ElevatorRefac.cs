using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElevatorType
{

    MoveUp,
    MoveDown,
    DoorClosed,
}

public class ElevatorRefac : MonoBehaviour
{
    public GameObject olaf;
    public ElevatorType elevatorType;
    public float distance = 10f;


    private float DoorSpeed = 1f;
    [SerializeField]
    private float ElevatorSpeed = 5f;

    private bool bDoorIsOpen;
    private bool bOpenDoorNow;


    private GameObject Door;
    private GameObject[] leftRightDoor = new GameObject[2];
    private Vector3[] DoorsClosedPosition = new Vector3[2];
    private Vector3[] DoorsOpenPosition = new Vector3[2];

    private GameManager gameManager;
    private RadioSoundManager radio;
    private float threshhold;

    private ElevatorSouds elevatorAudio;
    bool CR_running = false;
    // Start is called before the first frame update
    void Start()
    {
        setUpDoors();

        threshhold = leftRightDoor[0].transform.localScale.x * 0.005f;
        elevatorAudio = GameObject.FindObjectOfType<ElevatorSouds>();

        
    }

    // Update is called once per frame
    void Update()
    {



        checkDoorState();




    }

    void setUpDoors()
    {
        Door = transform.Find("Door").gameObject;
        leftRightDoor[0] = Door.transform.Find("LeftDoor").gameObject;
        leftRightDoor[1] = Door.transform.Find("RightDoor").gameObject;

        //open and close Positions
        DoorsClosedPosition[0] = leftRightDoor[0].transform.localPosition;
        DoorsClosedPosition[1] = leftRightDoor[1].transform.localPosition;

        DoorsOpenPosition[0] = (leftRightDoor[0].transform.localPosition - leftRightDoor[0].transform.localScale.x * Vector3.right);
        DoorsOpenPosition[1] = (leftRightDoor[1].transform.localPosition - leftRightDoor[1].transform.localScale.x * Vector3.left);


        if (elevatorType == ElevatorType.DoorClosed)
        {
            bDoorIsOpen = false;
        }
        else
        {
            //Door is open at start
            leftRightDoor[0].transform.localPosition = DoorsOpenPosition[0];
            leftRightDoor[1].transform.localPosition = DoorsOpenPosition[1];
            bDoorIsOpen = true;
        }




    }

    void checkDoorState()
    {
        //Check Door Open or Closed completely
        if (Vector3.Distance(DoorsOpenPosition[0], leftRightDoor[0].transform.localPosition) < threshhold)
            bDoorIsOpen = true;

        if (Vector3.Distance(DoorsClosedPosition[0], leftRightDoor[0].transform.localPosition) < threshhold)
            bDoorIsOpen = false;
    }


    public void openCloseDoor()
    {



        if (bDoorIsOpen == false)
        {
            leftRightDoor[0].transform.localPosition = Vector3.Lerp(leftRightDoor[0].transform.localPosition, DoorsOpenPosition[0]   , Time.deltaTime * DoorSpeed);
            leftRightDoor[1].transform.localPosition = Vector3.Lerp(leftRightDoor[1].transform.localPosition, DoorsOpenPosition[1]  , Time.deltaTime * DoorSpeed);
        }
        else
        {
            leftRightDoor[0].transform.localPosition = Vector3.Lerp(leftRightDoor[0].transform.localPosition, DoorsClosedPosition[0], Time.deltaTime * DoorSpeed);
            leftRightDoor[1].transform.localPosition = Vector3.Lerp(leftRightDoor[1].transform.localPosition, DoorsClosedPosition[1], Time.deltaTime * DoorSpeed);
        }






    }
    private void moveDistance()
    {
        if (elevatorType == ElevatorType.MoveDown)
        {
            transform.localPosition = transform.localPosition + Vector3.down * Time.deltaTime * ElevatorSpeed;
            olaf.transform.Translate(Vector3.down * Time.deltaTime * ElevatorSpeed*0.5f, Space.World);
        }
        if (elevatorType == ElevatorType.MoveUp)
        {
            transform.localPosition = transform.localPosition + Vector3.up * Time.deltaTime * ElevatorSpeed;
            olaf.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }

    }


    IEnumerator moveUpDown()
    {
        CR_running = true;
        while (bDoorIsOpen)
        {
           // Debug.Log("Door Oopen!");
            openCloseDoor();
            yield return 0;
        }
        //Debug.Log("Door closed!");
        yield return new WaitForSeconds(0.5f);


        Vector3 destination = transform.localPosition;
        destination += (elevatorType == ElevatorType.MoveUp) ? new Vector3(0, distance, 0) : new Vector3(0, -distance, 0);
        Debug.Log("davor");
        while (Mathf.Abs( Vector3.Distance(transform.localPosition, destination)) > threshhold)
        {
           // Debug.Log("ziel noch nicht erreicht");
            elevatorAudio.playSounds();
           // Debug.Log("ziel noch nicht erreicht2");
            moveDistance();
            yield return 0;
        }
       // Debug.Log("ziel erreicht");
        elevatorAudio.stopSounds();
        elevatorAudio.playBellSound();
        yield return new WaitForSeconds(1);

        while (!bDoorIsOpen)
        {
            openCloseDoor();
            yield return 0;
        }
        //CR_running = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !CR_running)
        {

            if (elevatorType != ElevatorType.DoorClosed)
            {

                StartCoroutine(moveUpDown());
               // Debug.Log("Triggered!");
            }
            else
            {
                ElevatorReneStartCutscene Rene = GameObject.FindObjectOfType<ElevatorReneStartCutscene>();
                if (Rene != null)
                {
                    StartCoroutine(Rene.BeginHotelLevel());
                    CR_running = true;
                }
            }
        }



    }
}


