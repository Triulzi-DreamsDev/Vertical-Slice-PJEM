using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport_AV : GameCTRL
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rooms = 2;
            SceneManager.LoadScene("ArchivosViejos");
        }
    }
}
