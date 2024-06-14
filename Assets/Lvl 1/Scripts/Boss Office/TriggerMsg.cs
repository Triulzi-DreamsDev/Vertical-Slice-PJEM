using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMsg : GameCTRL
{
    [SerializeField]
    GameObject mensajeUI, respuesta;
    // Start is called before the first frame update
    void Start()
    {
        mensajeUI.SetActive(false);
        respuesta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Contestar()
    {
        mensajeUI.SetActive(false);
        respuesta.SetActive(true);
        // Restablece la variable estática cuando se contesta
        GameCTRL.isMessageActive = true;
    }

    public void Enviar()
    {
        respuesta.SetActive(false);
        // Restablece la variable estática cuando se envía la respuesta
        GameCTRL.isMessageActive = false;
    }

    public void Ignorar()
    {
        mensajeUI.SetActive(false);
        // Restablece la variable estática cuando se ignora el mensaje
        GameCTRL.isMessageActive = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Solo muestra el mensaje si el jugador entra y no hay otro mensaje activo
        if (collider.gameObject.tag == "Player" && questState == 1 && !GameCTRL.isMessageActive)
        {
            mensajeUI.SetActive(true);
            // Marca que un mensaje está activo
            GameCTRL.isMessageActive = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // Restablece la variable estática cuando el jugador sale del área de trigger
        if (collider.gameObject.tag == "Player")
        {
            GameCTRL.isMessageActive = false;
        }
    }
}
