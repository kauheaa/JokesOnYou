using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDoorTrigger : MonoBehaviour
{
    public DavDialogues davDialogues;
    private Collider triggerCollider;

    void Start()
    {
        // Assuming your collider is attached to the same GameObject as this script
        triggerCollider = GetComponent<Collider>();
    }

    public void SetTriggerState(bool state)
    {
        triggerCollider.isTrigger = state;
    }
    
}
