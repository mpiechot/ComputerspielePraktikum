using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosterShow : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Image img;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerevent startet");
        if (other.tag == "Player")
        {
            img.gameObject.SetActive(true);
            text.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("triggerevent endet");
        if (other.tag == "Player")
        {
            img.gameObject.SetActive(false);
            text.enabled = false;
        }
    }
}
