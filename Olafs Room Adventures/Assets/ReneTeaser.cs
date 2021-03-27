using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ReneTeaser : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cineCam;
    [SerializeField]
    private Transform EndState;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(teaser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator teaser()
    {
        yield return new WaitForSeconds(22);
        float startTime = Time.time;
        //cineCam.LookAt = transform;
        while (Time.time - startTime <= 1)
        { // until one second passed
            transform.position = Vector3.Lerp(transform.position, EndState.position, (Time.time - startTime)*0.1f); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
    }
}
