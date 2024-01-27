using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaxiPoleInteraction : MonoBehaviour
{
    public TMP_Text dialogueText;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with Taxi Pole");

            // Check if the Taxi Pole's collider is enabled
            Collider taxiPoleCollider = GetComponent<Collider>();
            if (taxiPoleCollider != null && taxiPoleCollider.enabled)
            {
                StartInteraction();
            }
            else
            {
                Debug.Log("Taxi Pole collider is not enabled.");
            }
        }
    }

    void StartInteraction()
    {
        // Perform your interaction logic here
        Debug.Log("Start interaction");
        dialogueText.text = "Hmm.. I don't know the number";
        // You might want to add additional logic here based on the interaction.
    }
}
