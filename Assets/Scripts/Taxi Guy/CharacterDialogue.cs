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

    public GameObject textPanel;
    public GameObject dialoguePanel;

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
        if (other.CompareTag("Player") && dialogueCompleted)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = "PLAYER: You are a taxi";
            taskText.text = "";
            textPanel.SetActive(false);
            dialogueCompleted = false;
        }
    }

    void TriggerDialogue()
    {
        if (dialogues.Length > 0)
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(DisplayDialogue());
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
            dialoguePanel.SetActive(true);
            // Set the text on the UI element for a sentence
            dialogueText.text = sentence;

            // Wait for 'E' input to proceed to the next sentence
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        textPanel.SetActive(true);

        // Set the task in the UI
        SetTask("Call Taxi guy a taxi.");

        // Set the dialogueCompleted flag
        dialogueCompleted = true;

        // Enable the Taxi Pole collider trigger immediately when the dialogue is completed
        EnableTaxiPoleCollider(true);
    }


    void Update()
    {
        // Check for 'E' input to clear the UI text
        if (dialogueCompleted && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
        }
    }
}