using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEscritorio : GameCTRL
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [SerializeField]
    GameObject mensajeUI;
    // Start is called before the first frame update
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {

        if (playerInRange && tinesArchivo == true)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                mensajeUI.SetActive(true);
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
            mensajeUI.SetActive(false);
        }
    }
}
