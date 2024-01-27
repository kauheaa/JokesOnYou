using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroceriesDialogue : MonoBehaviour
{
    public string[] dialogues;
    private bool dialogueTriggered = false;
    private bool dialogueCompleted = false;
    public TMP_Text dialogueText;

    public TMP_Text taskText;
    public GameObject groceries;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogueTriggered)
        {
            dialogueTriggered = true;
            TriggerDialogue();
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
    }
    void Update()
    {
        // Check for 'E' input to clear the UI text
        if (dialogueCompleted && Input.GetKeyDown(KeyCode.E))
        {
            // Clear the UI text
            dialogueText.text = "";
            groceries.SetActive(true);
            taskText.text = "Take the groceries back home";
        }
    }
}
