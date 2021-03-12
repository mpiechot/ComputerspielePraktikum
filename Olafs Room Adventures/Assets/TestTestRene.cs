using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTestRene : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
