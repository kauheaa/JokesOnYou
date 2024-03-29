using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaxiPoleInteraction : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the Taxi Pole's collider is enabled
            Collider taxiPoleCollider = GetComponent<Collider>();
            if (taxiPoleCollider != null && taxiPoleCollider.enabled)
            {
                dialoguePanel.SetActive(true);
                StartInteraction();
            }
            else
            {
                return;
            }
        }
    }

    void StartInteraction()
    {
        dialogueText.text = "Hmm.. I don't know the number";
    }
}
