using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPplayer : MonoBehaviour
{
    public GameObject Olaf;
    // Start is called before the first frame update
    void Start()
    {
        Olaf.transform.position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
}
