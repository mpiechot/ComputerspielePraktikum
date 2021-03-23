using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointActivator : MonoBehaviour
{
    public Component checkpoint_to_activate;
    public float delay;
    private bool already_activated = false;

    public UnityEvent CheckpointPassedEvent;
    public UnityEvent ActivationDelayExpiredEvent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !already_activated)
        {
            Debug.Log("Start activating checkpoints");
            already_activated = true;
            StartCoroutine(activeCheckpoint(delay));
            CheckpointPassedEvent.Invoke();
        }
    }

    private IEnumerator activeCheckpoint(float delay)
    {
        yield return new WaitForSeconds(delay);
        ActivateCheckpoint();
        ActivationDelayExpiredEvent.Invoke();
        Debug.Log("checkpoint activates");
    }
    public void ActivateCheckpoint()
    {
        Rigidbody[] rigidbodies = checkpoint_to_activate.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
