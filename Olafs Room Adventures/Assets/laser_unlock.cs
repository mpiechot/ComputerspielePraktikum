using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class laser_unlock : MonoBehaviour
{
    [SerializeField]
    private GameObject lock1, lock2;

    [SerializeField]
    private TextMeshProUGUI key;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0 && key.text == "1")
        {
            lock1.SetActive(false);
            count++;
        }
        if (count == 1 && key.text == "2")
        {
            lock2.SetActive(false);
            count++;
        }
    }
}
