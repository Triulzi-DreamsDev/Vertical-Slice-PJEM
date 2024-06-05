using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : GameCTRL
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
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(false);
        }

        if (questState == 3 || questState == 5)
        {
            visualCue.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }
}