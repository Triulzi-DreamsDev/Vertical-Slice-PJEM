using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : GameCTRL
{
    // Start is called before the first frame update
    // Referencia al componente TextMesh
    public TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        // Asigna el texto con el nombre del jugador
        textMesh.text = $"Muy bien \"{nameOfPlayer}\" es momento de comenzar esta aventura";
    }
}
