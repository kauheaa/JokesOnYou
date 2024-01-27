using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeDialogue : MonoBehaviour
{
    public Transform teleportDestination;
    public GroceriesDialogue groceries;
    public TMP_Text dialogueText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && groceries.groceries.activeInHierarchy == true)
        {
            TeleportPlayer(teleportDestination.position);
            StartCoroutine(DisplayDialogue());
        }
        else
        {
            groceries.dialogueText.text = "There's no going back home without the breakfast supplies.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                groceries.dialogueText.text = "";
            }
        }
    }
    void TeleportPlayer(Vector3 destination)
    {
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            playerTransform.position = destination;
        }
    }

    IEnumerator DisplayDialogue()
    {
        // Display the first dialogue
        dialogueText.text = "PLAYER: Honneeeyyy I'm homee";

        // Wait for the next 'E' key press
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "WIFE: Woohooo breakfast!!";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "Wife: Why the hook did you bring 12 loafs of bread?";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

    }
}
