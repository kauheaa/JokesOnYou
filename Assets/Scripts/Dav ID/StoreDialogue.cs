using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDialogue : MonoBehaviour
{
    public DavDialogues davDialogues;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && davDialogues.storeIsOpen == true)
        {
            davDialogues.dialogueText.text = "Part-timer is at work. Store is open";
            if (Input.GetKeyDown(KeyCode.E))
            {
                davDialogues.dialogueText.text = "";
            }
        }
       else
        {
            davDialogues.dialogueText.text = "New part-timer seems to be late";
            if (Input.GetKeyDown(KeyCode.E))
            {
                davDialogues.dialogueText.text = "";
            }
        }
    }
}
