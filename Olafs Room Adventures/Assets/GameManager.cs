using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int collectedKeys = 0;
    [SerializeField]
    private TextMeshProUGUI keysText; 

    public void OnCollectKey()
    {
        collectedKeys++;
        keysText.text = collectedKeys+"";
    }
}
