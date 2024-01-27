using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour
{
    public string[] dialogues;
    private bool dialogueTriggered = false;

    public TMP_Text dialogueText;      // Reference to the UI Text element for dialogues

    private bool dialogueCompleted = false;
    public bool DialogueCompleted
    {
        get { return dialogueCompleted; }
    }

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
            Debug.LogWarning("No dialogues set for this character.");
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
