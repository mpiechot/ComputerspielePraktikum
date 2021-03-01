using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
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
        float currentTime1 = Time.time * timeSpeed + initialPosition.x + offset;
        float currentTime2 = Time.time * timeSpeed + initialPosition.y + offset;
        float currentTime3 = Time.time * timeSpeed + initialPosition.z + offset;

        transform.position = initialPosition + 
            Vector3.right * Mathf.Sin(currentTime1) * amplitude + 
            Vector3.up * Mathf.Cos(currentTime2) * amplitude +
            Vector3.forward * Mathf.Sin(currentTime3) * amplitude;
        transform.rotation = initialRotation * Quaternion.Euler(
            Mathf.Sin(currentTime1) * amplitude,
            Mathf.Sin(currentTime1) * amplitude,
            Mathf.Sin(currentTime1) * amplitude);
    }
}
