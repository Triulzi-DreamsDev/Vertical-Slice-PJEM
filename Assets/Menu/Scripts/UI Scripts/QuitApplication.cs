using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{

    // Este m�todo ser� llamado cuando el bot�n sea presionado
    public void QuitGame()
    {
        // Esto cerrar� la aplicaci�n cuando se ejecute en una build
        Application.Quit();

    }

}
