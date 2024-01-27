using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterDialogue : MonoBehaviour
{

    public string[] dialogues;
    private bool dialogueTriggered = false;

    public TMP_Text dialogueText;      // Reference to the UI Text element for dialogues
    public TMP_Text taskText;          // Reference to the UI Text element for tasks
    public GameObject taxiPoleObject;  // Reference to the Taxi Pole object

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

    void SetTask(string task)
    {
        taskText.text = task;

        // Enable interaction with the Taxi Pole when the dialogue is completed
        if (taxiPoleObject != null && dialogueCompleted)
        {
            EnableTaxiPoleCollider(true);
        }
    }

    void EnableTaxiPoleCollider(bool enable)
    {
        Collider taxiPoleCollider = taxiPoleObject.GetComponent<Collider>();

        if (taxiPoleCollider != null)
        {
            taxiPoleCollider.isTrigger = enable;
            Debug.Log("Taxi Pole collider trigger enabled: " + enable);
        }
        else
        {
            Debug.LogError("Collider component not found on the specified object.");
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

        // Set the task in the UI
        SetTask("Call Taxi guy a taxi.");

        // Set the dialogueCompleted flag
        dialogueCompleted = true;
        Debug.Log("Dialogue completed: " + dialogueCompleted);

        // Enable the Taxi Pole collider trigger immediately when the dialogue is completed
        EnableTaxiPoleCollider(true);
    }


    void Update()
    {
        // Check for 'E' input to clear the UI text
        if (dialogueCompleted && Input.GetKeyDown(KeyCode.E))
        {
            // Clear the UI text
            dialogueText.text = "";

            // You can add additional logic here based on the quest/task
            // For example, complete the quest or update the UI
        }
    }
}