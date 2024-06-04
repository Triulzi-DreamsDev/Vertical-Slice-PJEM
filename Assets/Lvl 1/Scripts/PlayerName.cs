using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : GameCTRL
{
    public TMP_InputField usernameInputField;
    public void SaveUsername()
    {
        // Guarda el nombre de usuario cuando se presiona el botón
        nameOfPlayer = usernameInputField.text;
        PlayerPrefs.SetString("Username", nameOfPlayer);

        // Imprime el nombre en la consola
        Debug.Log("Nombre de usuario guardado: " + nameOfPlayer);
    }
}
