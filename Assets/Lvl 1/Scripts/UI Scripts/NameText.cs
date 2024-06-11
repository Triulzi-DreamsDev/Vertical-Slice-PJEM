using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// Clase NameText que hereda de GameCTRL.
/// Se utiliza para establecer el nombre del jugador en un componente TextMeshProUGUI.
/// </summary>
public class NameText : GameCTRL
{
    /// <summary>
    /// Componente TextMeshProUGUI donde se mostrará el nombre del jugador.
    /// </summary>
    public TextMeshProUGUI textMesh;

    /// <summary>
    /// Método Start que se llama al inicio del juego.
    /// Establece el texto del TextMeshProUGUI con el nombre del jugador.
    /// </summary>
    void Start()
    {
        textMesh.text = nameOfPlayer;

    }

}
