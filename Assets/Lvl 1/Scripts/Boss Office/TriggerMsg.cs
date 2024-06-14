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

    }

    public void Enviar()
    {
        respuesta.SetActive(false);

    }

    public void Ignorar()
    {
        mensajeUI.SetActive(false);

    }

    private void OnTriggerEnter(Collider collider)
    {
        // Solo muestra el mensaje si el jugador entra y no hay otro mensaje activo
        if (collider.gameObject.tag == "Player" && questState == 1 && !GameCTRL.isMessageActive)
        {
            mensajeUI.SetActive(true);
        }
    }
}
