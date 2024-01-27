using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCardItem : MonoBehaviour
{
    public Dialogues dialoguesScript; // Reference to the Dialogues script

    public GameObject keyCard;

    public TMP_Text questText;

    public GameObject devWall;

    void Update()
    {
        // Check if the dialogues script is completed
        if (dialoguesScript != null && dialoguesScript.DialogueCompleted)
        {
            GetKeyCard();
        }

    }
    void GetKeyCard()
    {
        keyCard.SetActive(true);

        questText.text = "Find Dav's ID";

        OpenDevDoor(true);
    }

    void OpenDevDoor(bool enable)
    {
        Collider devCollider = devWall.GetComponent<Collider>();
        devCollider.isTrigger = enable;
    }
}
