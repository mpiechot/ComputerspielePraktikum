using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{

    [SerializeField]
    private GameObject continueButton;

    [SerializeField]
    private GameObject gameManager;

    public void DeactivatePlayerInteraction()
    {
        continueButton.SetActive(false);
        gameManager.GetComponent<GravityController>().DeactivateGravity();
        gameManager.GetComponent<GravityController>().enabled = false;
    }

    public void ActivatePlayerInteraction()
    {
        continueButton.SetActive(true);
        gameManager.GetComponent<GravityController>().enabled = true;
    }

}
