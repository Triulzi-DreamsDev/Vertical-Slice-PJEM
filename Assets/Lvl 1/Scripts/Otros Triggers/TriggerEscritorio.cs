using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEscritorio : GameCTRL
{
    [SerializeField]
    GameObject mensajeUI;
    // Start is called before the first frame update
    void Start()
    {
        mensajeUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && tinesArchivo == true)
        {
            mensajeUI.SetActive(true);
        }
    }

}
