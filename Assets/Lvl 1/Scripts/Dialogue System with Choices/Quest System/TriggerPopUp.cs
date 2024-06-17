using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPopUp : GameCTRL
{
    [SerializeField]
    private GameObject mensajeUI; // UI element for the message
    [SerializeField]
    private GameObject destoroyah; 

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the message UI element
        mensajeUI.SetActive(false);
    }

    // Method to detect when another collider enters the trigger collider
    private void OnTriggerEnter(Collider collider)
    {
        // Only show the message UI if the collider belongs to the player
        if (tinesArchivo == true && collider.gameObject.CompareTag("Player"))
        {
            mensajeUI.SetActive(true);
        }
    }

    // Method to detect when another collider exits the trigger collider
    private void OnTriggerExit(Collider collider)
    {
        // Only hide the message UI if the collider belongs to the player
        if (tinesArchivo == true && collider.gameObject.CompareTag("Player"))
        {
            mensajeUI.SetActive(false);
            Destroy(gameObject); // Destroy the trigger area to prevent the message from reappearing
            Destroy(destoroyah);
            Destroy(this);
        }
    }
}
