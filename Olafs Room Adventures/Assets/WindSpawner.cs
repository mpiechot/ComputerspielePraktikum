using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] windEffects;
    [SerializeField]
    private Vector3[] spawnPositions;
    [SerializeField]
    private float spawnTimer = 2f;

    private bool waiting = false;


    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            Instantiate(windEffects[Random.Range(0, windEffects.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)], Quaternion.identity);
            StartCoroutine("WaitForNextWind");
        }
    }
    private IEnumerator WaitForNextWind()
    {
        waiting = true;
        yield return new WaitForSeconds(spawnTimer);
        waiting = false;
    }

}
