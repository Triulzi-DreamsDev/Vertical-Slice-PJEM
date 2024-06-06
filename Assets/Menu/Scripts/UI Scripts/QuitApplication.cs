using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{

    // Este método será llamado cuando el botón sea presionado
    public void QuitGame()
    {
        // Esto cerrará la aplicación cuando se ejecute en una build
        Application.Quit();

    }

}
