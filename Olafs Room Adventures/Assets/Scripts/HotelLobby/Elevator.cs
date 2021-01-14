using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Elevator : MonoBehaviour
{
    /*

    
   
    
    
    
    
    
    
    
    private bool bTriggeredOnceBefore = false;
    

    private GameManager gameManager;
    private RadioSoundManager radio;
    

    // Start is called before the first frame update
    void Start()
    {

        //sound Set-up
        

        //Door set-up
       

        
        

       

    }

    // Update is called once per frame
    void Update()
    {
        
        

                

                //door is open/Closed after it moved to end Position:
       


    }



    

   

    


    
    public IEnumerator closeDoor()
    {






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

    public IEnumerator MoveUpDown()
    {
       
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !bTriggeredOnceBefore)
        {
            //bTriggeredOnceBefore = true;
                switch (elevatorType)
                {
                    case ElevatorType.DoorClosedAtStart:
                        StartCoroutine(BeginHotelLevel());
                    break;


                    case ElevatorType.MoveUp:
                    StartCoroutine(MoveUpDown());
                    break;

                case ElevatorType.MoveDown:
                    StartCoroutine(MoveUpDown());
                    break;
            }


        }
    }
*/
   
}
