using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [SerializeField]
    private float interactionRange = 10f;
    [SerializeField]
    private InteractUI interactUI;

    void Update()
    {
        Collider[] inRange = Physics.OverlapSphere(transform.position, interactionRange, LayerMask.GetMask("Interactable"));
        if(inRange.Length == 0)
        {
            interactUI.Hide();
        }
        else
        {
           interactUI.Show();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryUse(inRange);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

    private void TryUse(Collider[] inRange)
    {
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
