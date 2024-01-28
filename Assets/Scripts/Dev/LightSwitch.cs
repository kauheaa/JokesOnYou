using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightSwitch : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text taskText;
    public bool DialogueCompleted = false;
    public GameObject dialoguePanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the Taxi Pole's collider is enabled
            Collider lightSwitchCollider = GetComponent<Collider>();
            if (lightSwitchCollider != null && lightSwitchCollider.enabled)
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
        dialogueText.text = "*CLICK*";
        taskText.text = "";
        DialogueCompleted = true;
        DisableLightSwitchCollider(false);

    }
    void DisableLightSwitchCollider(bool disable)
    {
        Collider lightSwitchCollider = GetComponent<Collider>();
        lightSwitchCollider.isTrigger = disable;
    }
}
