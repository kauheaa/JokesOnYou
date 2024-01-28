using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDoorTrigger : MonoBehaviour
{
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
