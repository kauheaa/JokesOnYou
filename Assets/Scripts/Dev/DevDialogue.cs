using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DevDialogue : MonoBehaviour
{
    public string[] dialogues;
    private bool dialogueTriggered = false;

    public TMP_Text dialogueText;

    private bool dialogueCompleted = false;

    public GameObject requiredItem;
    public TMP_Text taskText;
    public TMP_Text iDTaskText;

    public GameObject lightSwitch;
    public GameObject iD;
    public GameObject keyCard;

    public KeyCardItem keyCardItem;
    public bool DialogueCompleted
    {
        get { return dialogueCompleted; }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogueTriggered && requiredItem.activeInHierarchy == true)
        {
            dialogueTriggered = true;
            TriggerDialogue();
        }

        else if (lightSwitch.GetComponent<LightSwitch>().DialogueCompleted)
        {
            StartCoroutine(DisplayLightSwitchDialogue());
        }
        else
        {
            dialogueText.text = "DEV: What?";
            if (dialogueCompleted && Input.GetKeyDown(KeyCode.E))
            {
                // Clear the UI text
                dialogueText.text = "";
            }
        }
    }

    void TriggerDialogue()
    {
        if (dialogues.Length > 0)
        {
            StartCoroutine(DisplayDialogue());
        }
    }
    IEnumerator DisplayLightSwitchDialogue()
    {
        // Display the first dialogue
        dialogueText.text = "DEV: Thanks a bunch";

        // Wait for the next 'E' key press
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        dialogueText.text = "Player: Why do you not want the light on?";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        dialogueText.text = "Dev: It attracts bugs";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        dialogueText.text = "Hey! I just remembered, Dav must be looking for this. If you see him around could you give it to him?";
        // Wait for the next 'E' key press
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        // Clear the UI text
        dialogueText.text = "";

        // Set dialogueCompleted flag
        dialogueCompleted = true;

        //keyCard.SetActive(false);
        iD.SetActive(true);
        lightSwitch.GetComponent<LightSwitch>().DialogueCompleted = false;

        keyCardItem.gotId = true;
        keyCardItem.keyCard.SetActive(false);

        iDTaskText.text = "Take ID back to DAV ";
    }
    void SetTask(string task)
    {
        taskText.text = task;

        // Enable interaction with the Taxi Pole when the dialogue is completed
        if (lightSwitch != null && dialogueCompleted)
        {
            EnableLightSwitchCollider(true);
        }
    }

    void EnableLightSwitchCollider(bool enable)
    {
        Collider lightSwitchCollider = lightSwitch.GetComponent<Collider>();

        if (lightSwitchCollider != null)
        {
            lightSwitchCollider.isTrigger = enable;
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

        // Set the task in the UI
        SetTask("Switch game studio in dark mode");

        // Set the dialogueCompleted flag
        dialogueCompleted = true;

        // Enable the Taxi Pole collider trigger immediately when the dialogue is completed
        EnableLightSwitchCollider(true);
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
