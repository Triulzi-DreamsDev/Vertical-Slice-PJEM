using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : GameCTRL
{
   private GameObject player;
   // private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
        
        playerInRange = false;
       // visualCue = player.transform.Find("VisualCue").gameObject;
       // visualCue.SetActive(false);
        
    }

    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }

    private void Update()
    {
        //visualCue = player.transform.Find("VisualCue").gameObject;

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
           // visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
           // visualCue.SetActive(false);
        }

        if (questState == 3 || questState == 5)
        {
           // visualCue.SetActive(false);
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
           // visualCue.SetActive(false);
        }
    }
}