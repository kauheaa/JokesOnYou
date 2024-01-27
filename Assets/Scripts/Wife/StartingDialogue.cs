using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingDialogue : MonoBehaviour
{
    public string[] dialogues;
    private bool dialogueTriggered = false;

    public TMP_Text dialogueText;      // Reference to the UI Text element for dialogues

    private bool dialogueCompleted = false;
    public PlayerMovement playerMovement;
    public bool DialogueCompleted
    {
        get { return dialogueCompleted; }
    }

    public Transform teleportDestination; // Reference to the teleport destination
    void Start()
    {
        // Get the PlayerMovement script component
        playerMovement = GameObject.Find("Churro").GetComponent<PlayerMovement>();
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
            // Disable player movement here
            playerMovement.enabled = false;

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

        dialogueCompleted = true;

        // Teleport the player to the specified destination
        if (teleportDestination != null)
        {
            TeleportPlayer(teleportDestination.position);
        }
    }

    void TeleportPlayer(Vector3 destination)
    {
        GameObject playerObject = GameObject.Find("Churro");

        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            playerTransform.position = destination;
            playerTransform.rotation = Quaternion.Euler(0f,0f,0f);
            playerMovement.enabled = true;
        }
    }

    void Update()
    {
        if (dialogueCompleted && Input.GetKeyDown(KeyCode.E))
        {
            dialogueText.text = "";

        }
    }
}
