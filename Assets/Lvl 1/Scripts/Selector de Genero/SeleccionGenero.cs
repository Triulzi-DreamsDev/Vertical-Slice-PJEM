using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionGenero : MonoBehaviour
{
    public void SeleccionarHombre()
    {
        PlayerPrefs.SetInt("Genero", 1); // 1 representa hombre
        Debug.Log("G�nero seleccionado: Hombre");
        
    }

    public void SeleccionarMujer()
    {
        PlayerPrefs.SetInt("Genero", 0); // 0 representa mujer
        Debug.Log("G�nero seleccionado: Mujer");
        
    }
}