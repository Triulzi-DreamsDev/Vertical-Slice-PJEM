using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorModelo3D : GameCTRL
{
    public GameObject modeloHombre;
    public GameObject modeloMujer;

    private void Awake()
    {
        if (modeloHombre == null || modeloMujer == null)
        {
            Debug.LogError("Los modelos 3D no est�n asignados en el Inspector.");
            return;
        }

        // Recuperar la selecci�n de g�nero de PlayerPrefs
        int generoSeleccionado = PlayerPrefs.GetInt("Genero", 1); // 1 por defecto es hombre

        esHombre = generoSeleccionado == 1;

        modeloHombre.SetActive(esHombre);
        modeloMujer.SetActive(!esHombre);
    }
}

