using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorReneStartCutscene : MonoBehaviour
{
    public Transform blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
       // radio = FindObjectOfType<RadioSoundManager>();
        blackScreen = transform.Find("BlackScreen");
        blackScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
