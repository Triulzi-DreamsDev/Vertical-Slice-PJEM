using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport_AN : GameCTRL
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rooms = 1;
            SceneManager.LoadScene("ArchivosNuevos");
        }
    }
}
