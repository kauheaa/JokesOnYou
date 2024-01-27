using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStudioDialogue : MonoBehaviour
{
    public KeyCardItem keyCardItem;
    public DavDialogues davDialogues;
    private Collider triggerCollider;

    void Start()
    {
        // Assuming your collider is attached to the same GameObject as this script
        triggerCollider = GetComponent<Collider>();
    }

    public void SetTriggerState(bool isTrigger)
    {
        triggerCollider.isTrigger = isTrigger;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyCardItem.keyCard.activeInHierarchy == true)
        {
            davDialogues.dialogueText.text = "Door unlocked with key card.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                davDialogues.dialogueText.text = "";

            }
        }
        else
        {
            davDialogues.dialogueText.text = "You don't have the Key Card";
            if (Input.GetKeyDown(KeyCode.E))
            {
                davDialogues.dialogueText.text = "";
            }
        }
    }
}
