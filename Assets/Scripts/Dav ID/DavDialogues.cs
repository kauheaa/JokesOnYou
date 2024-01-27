using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DavDialogues : MonoBehaviour
{
    public string[] dialogues;
    private bool dialogueTriggered = false;

    public TMP_Text dialogueText;      // Reference to the UI Text element for dialogues

    private bool dialogueCompleted = false;
    public bool DialogueCompleted
    {
        get { return dialogueCompleted; }
    }
    public GameObject requiredItem;

    public DevDialogue taskText;
    public bool storeIsOpen = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogueTriggered && requiredItem.activeInHierarchy == false)
        {
            dialogueTriggered = true;
            TriggerDialogue();
        }
        else if (requiredItem.activeInHierarchy == true)
        {
            StartCoroutine(DisplayIDDialogue());
        }
    }

    void TriggerDialogue()
    {
        if (dialogues.Length > 0)
        {
            StartCoroutine(DisplayDialogue());
        }
        else
        {
            return;
        }
    }
    public StoreDoorTrigger doorTrigger;
    IEnumerator DisplayIDDialogue()
    {
        // Display the first dialogue
        dialogueText.text = "DAV: you found my ID! Thank you";

        // Wait for the next 'E' key press
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "PLAYER: My pleasure DavID";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "DAVID the game dev: Did you get your bread yet";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "PLAYER: Nope, the store is still not open. The new part timer is late...";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "DAVID the part-timer: OH SHOOT! I forgot! My part-time job! I gotta run, BYE!";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        requiredItem.SetActive(false);

        storeIsOpen = true;

        doorTrigger.SetTriggerState(true);
        taskText.iDTaskText.text = "Get the groceries";
    }

    IEnumerator DisplayDialogue()
    {
        foreach (string sentence in dialogues)
        {
            // Set the text on the UI element for a sentence
            dialogueText.text = sentence;

            // Wait for 'E' input to proceed to the next sentence
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        // Set the dialogueCompleted flag
        dialogueCompleted = true;
        Debug.Log("Dialogue completed: " + dialogueCompleted);
    }


    void Update()
    {
        // Check for 'E' input to clear the UI text
        if (dialogueCompleted && Input.GetKeyDown(KeyCode.E))
        {
            // Clear the UI text
            dialogueText.text = "";
        }
    }
}
