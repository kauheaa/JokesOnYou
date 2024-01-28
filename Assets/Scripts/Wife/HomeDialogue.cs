using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeDialogue : MonoBehaviour
{
    public Transform teleportDestination;
    public GroceriesDialogue groceries;
    public TMP_Text dialogueText;

    public GameObject dialoguePanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && groceries.groceries.activeInHierarchy == true)
        {
            TeleportPlayer(teleportDestination.position);
            dialoguePanel.SetActive(true);
            StartCoroutine(DisplayDialogue());
        }
        else
        {
            dialoguePanel.SetActive(true);
            groceries.dialogueText.text = "There's no going back home without the breakfast supplies.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                groceries.dialogueText.text = "";
                dialoguePanel.SetActive(false);
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

        dialoguePanel.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "WIFE: Woohooo breakfast!!";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        dialoguePanel.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "WIFE: Why the hook did you bring 12 loafs of bread?";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = ""; 
        dialoguePanel.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "PLAYER: They had eggs..."; 
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }
}
