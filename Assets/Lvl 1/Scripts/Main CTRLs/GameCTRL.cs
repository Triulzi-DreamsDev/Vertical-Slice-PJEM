using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameCTRL : MonoBehaviour
{
    public static string nameOfPlayer;
    public static int questState;
    public static bool esHombre;
    public static int rooms = 0;
    public static bool tinesArchivo;
    public static bool isMessageActive = false;

    // Start is called before the first frame update
    void Start()
    {
        questState = 0;

        //Quitar el comentario de lo de abajo para pruebas:
        //nameOfPlayer = "Gery";
        //esHombre = false;


    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
