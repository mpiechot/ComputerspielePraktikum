using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorReneStartCutscene : MonoBehaviour
{
    public Transform blackScreen;
    private RadioSoundManager radio;
    private ElevatorSouds elevatorAudio;
    private GameManager gameManager;
    bool openDoor = false;
    bool CR_running = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        radio = FindObjectOfType<RadioSoundManager>();
        elevatorAudio = GameObject.FindObjectOfType<ElevatorSouds>();
        blackScreen = transform.Find("BlackScreen");
        if (blackScreen != null)
        {
            blackScreen.gameObject.SetActive(true);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            GameObject.FindObjectOfType<ElevatorRefac>().openCloseDoor();
        }
    }


    public IEnumerator BeginHotelLevel()
    {
        CR_running = true;
        StartCoroutine(FindObjectOfType<GravityController>().LockGravityAndFreeFloat(7f));
        elevatorAudio.playSounds();
        while (radio.playRadioLouder())
        {
            yield return 0;
        }
        gameManager.FadeIn();
        blackScreen.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        elevatorAudio.playBellSound();
        yield return new WaitForSeconds(1.0f);
        openDoor = true;
        while (!radio.playRadioLouder())
        {
            yield return 0;
        }
        //openDoor = false;
        

    }

    private void OnTriggerEnter(Collider other)
    {
        

    }
}
