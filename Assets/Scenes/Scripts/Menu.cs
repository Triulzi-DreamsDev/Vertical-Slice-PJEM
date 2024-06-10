using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    /// <summary>
    /// Método llamado al presionar el botón de jugar que carga la escenea de juego.
    /// </summary>
    public void PlayGame()
    {
        // Cargar la escena del juego de forma asíncrona
        SceneManager.LoadSceneAsync(1);
    }
}
