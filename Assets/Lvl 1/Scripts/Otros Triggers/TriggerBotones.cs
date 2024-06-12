using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBotones : GameCTRL
{
    [SerializeField]
    GameObject DialogueChoices;
    // Start is called before the first frame update
    void Start()
    {
        DialogueChoices.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && tinesArchivo == false)
        {
            DialogueChoices.SetActive(true);
        }
    }
}
