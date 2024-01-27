using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCardItem : MonoBehaviour
{
    public DavDialogues dialoguesScript; // Reference to the Dialogues script

    public GameObject keyCard;

    public TMP_Text questText;

    public GameObject devWall;

    public bool gotId = false;
    public GameStudioDialogue gameStudioDialogue;
    void Update()
    {
        // Check if the dialogues script is completed
        if (dialoguesScript != null && dialoguesScript.DialogueCompleted && !gotId)
        {
            GetKeyCard();
            gameStudioDialogue.SetTriggerState(false);
        }

    }
    public void GetKeyCard()
    {
        keyCard.SetActive(true);

        if (keyCard.gameObject.activeInHierarchy == true)
        {
            questText.text = "Find Dav's ID";
        }
    }
}
