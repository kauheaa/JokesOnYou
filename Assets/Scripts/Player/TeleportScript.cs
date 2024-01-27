using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportDestination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }

    void TeleportPlayer(Transform playerTransform)
    {
        if (teleportDestination != null)
        {
            // Teleport the player to the specified destination
            playerTransform.position = teleportDestination.position;
            playerTransform.rotation = teleportDestination.rotation;
        }
    }
}
