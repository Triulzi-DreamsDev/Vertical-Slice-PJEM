using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerChoices : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        var dialogueManager = DialogueManagerChoices.GetInstance();

        if (playerInRange && !dialogueManager.dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.I)) //Press I to talk
            {
                dialogueManager.EnterDialogueMode(inkJSON);
            }
        }
        else if (playerInRange && dialogueManager.isDialoguePaused)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) //Press Space to resume
            {
                dialogueManager.ResumeDialogue();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
