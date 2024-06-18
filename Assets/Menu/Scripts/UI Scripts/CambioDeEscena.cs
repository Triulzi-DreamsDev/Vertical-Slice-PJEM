using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // M�todo para cargar la pr�xima escena
    public void CargarProximaEscena()
    {
        // Carga la pr�xima escena (aseg�rate de que la escena est� en el Build Settings)
        SceneManager.LoadScene("Lobby");
    }
}
