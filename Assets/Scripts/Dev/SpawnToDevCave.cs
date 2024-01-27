using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToDevCave : MonoBehaviour
{
    public Transform transformSpot;
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a GameObject with the specified wall tag
        if (other.CompareTag("devWall"))
        {
            // Check if the transform spot is found
            if (transformSpot != null)
            {
                // Teleport the player to the transform spot's position
                transform.position = transformSpot.transform.position;

            }
        }
    }
}
