using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    /// <summary>
    /// M�todo llamado al presionar el bot�n de jugar que carga la escenea de juego.
    /// </summary>
    public void PlayGame()
    {
        // Cargar la escena del juego de forma as�ncrona
        SceneManager.LoadSceneAsync(1);
    }
}
