using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // Método para cargar la próxima escena
    public void CargarProximaEscena()
    {
        // Carga la próxima escena (asegúrate de que la escena esté en el Build Settings)
        SceneManager.LoadScene("Lobby");
    }
}
