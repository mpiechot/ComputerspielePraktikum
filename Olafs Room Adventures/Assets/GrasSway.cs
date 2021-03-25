using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrasSway : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    [SerializeField]
    private float timeSpeed = 1.0f;

    [SerializeField]
    private float offset = 0.0f;

    [SerializeField]
    private float amplitude = 1.0f;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        float currentTime = Time.time * timeSpeed + initialPosition.x + offset;

        //transform.position = initialPosition + Vector3.right * Mathf.Sin(currentTime1) * amplitude1 + Vector3.up * Mathf.Sin(currentTime2) * amplitude2;
        transform.rotation = initialRotation * Quaternion.Euler(
            Mathf.Sin(currentTime) * amplitude,
            0,
            Mathf.Sin(currentTime) * amplitude);
    }
}
