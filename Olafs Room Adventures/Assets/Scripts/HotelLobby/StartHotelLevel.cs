using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartHotelLevel : MonoBehaviour
{
    public Image blackSceen;
    public GameObject controllsUI;
    

    private float alpha = 1f;
    private float startTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
       // elevator = FindObjectOfType<Elevator>().gameObject;
        //controllsUI = GameObject.Find("ShittyUI");
        if (controllsUI == null) { Debug.LogError("ShittyUI not found"); }
        
        if (blackSceen == null) { Debug.LogError("BlackScreen not found"); }
        controllsUI.SetActive(false);

        
        ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 1)
        {
            FindObjectOfType<Elevator>().playSounds();
        }

            if (Time.time > 3)
        {
            fadeIn();
            playRadioLouder(10);
        }

        if (Time.time > 8)
        {
            blackSceen.gameObject.SetActive(false);
            FindObjectOfType<Elevator>().stopSounds();
            FindObjectOfType<Elevator>().openDoor();
        }

        if (Time.time > 10)
        {
            controllsUI.SetActive(true);
            Destroy(gameObject);
        }

    }

    private void playRadioLouder(float lerpTime) 
    {
        if (startTime == 0)
        {
            startTime = Time.time;
            FindObjectOfType<RadioSoundManager>().startPlaying();
        }
        float timeSinceStarted = Time.time - startTime;
        float percentageComplete = timeSinceStarted / lerpTime;

        FindObjectOfType<RadioSoundManager>().setVolume(Mathf.Lerp(0, 1, percentageComplete));
        
    }

    private void fadeIn()
    {
        blackSceen.color = new Color(blackSceen.color.r, blackSceen.color.g, blackSceen.color.b, alpha);
        alpha = Mathf.Lerp(alpha, 0, 0.2f * Time.deltaTime);
    }
}
