using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : GameCTRL
{
    private GameObject player;
    private GameObject bossTrigger;
    [SerializeField]
    private GameObject NP;

    private GameObject canvasPlayer, visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    [Header("Interaction Conditions")]
    [SerializeField] private bool file; // Specify if interaction is conditional

    [Header("Configuraciones del NPC")]
    [SerializeField] private bool shouldRotate; // Determina si el NPC debe voltear hacia el jugador


    private Vector3 originalPosition;
    private Quaternion originalRotation;
    int cont = 0;

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        bossTrigger = GameObject.FindGameObjectWithTag("BossTrigger");

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

        // Guarda la posición y rotación original del NPC
        originalPosition = NP.transform.position;
        originalRotation = NP.transform.rotation;
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
        if (playerInRange && (!file || tinesArchivo == true) && !DialogueManager.GetInstance().dialogueIsPlaying)
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

        if (playerInRange)
        {
            if (shouldRotate)
            {
                LookAtPlayer();
            }
        }
        else
        {
            if (this.gameObject != bossTrigger)
            {
                ReturnToOriginalPosition();
            }
        }
        if (SeFueJefe && cont == 0) {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Avisa que alguien ya esta hablando
            isMessageActive = true;

            playerInRange = true;
            if (file)
            {
                visualCue.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Avisa que ya no esta hablando con esa persona
            isMessageActive = false;

            playerInRange = false;
            visualCue.SetActive(false);
        }
    }

    private void LookAtPlayer()
    {
        // Calcula la dirección desde el NPC hacia el jugador
        Vector3 direction = player.transform.position - NP.transform.position;
        direction.y = 0; // Ignora la componente vertical

        // Calcula la nueva rotación que debe tener el NPC para mirar al jugador
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Ajusta la rotación del NPC
        NP.transform.rotation = Quaternion.Slerp(NP.transform.rotation, rotation, Time.deltaTime * 5);
    }

    private void ReturnToOriginalPosition()
    {
        // Interpola la posición y rotación del NPC de vuelta a su estado original
        NP.transform.position = Vector3.Lerp(NP.transform.position, originalPosition, Time.deltaTime * 2);
        NP.transform.rotation = Quaternion.Slerp(NP.transform.rotation, originalRotation, Time.deltaTime * 2);
    }
}