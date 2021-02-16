using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [SerializeField]
    private float interactionRange = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryUse();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

    private void TryUse()
    {
        Collider[] inRange = Physics.OverlapSphere(transform.position, interactionRange, LayerMask.GetMask("Interactable"));
        foreach (Collider collider in inRange)
        {
            if (collider.tag == "Switch")
            {
                InteractableSwitch switchObj = collider.gameObject.GetComponent<InteractableSwitch>();
                switchObj.UseSwitch();
            }
        }
    }
}
