using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : GameCTRL
{
   private GameObject player;
    private GameObject canvasPlayer, visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
        
        playerInRange = false;

        canvasPlayer = player.transform.Find("Canvas").gameObject;
        visualCue = canvasPlayer.transform.Find("VisualCueHablar").gameObject;

        if (visualCue != null)
        {
            Debug.Log("Hijo encontrado: " + visualCue.name);
            visualCue.SetActive(false);
        }
        else
        {
            Debug.Log("Hijo no encontrado");
        }
        

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
            if (visualCue != null)
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