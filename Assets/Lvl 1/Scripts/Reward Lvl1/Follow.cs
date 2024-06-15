using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : GameCTRL
{
    [SerializeField]
    GameObject Particulas;

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        this.gameObject.transform.localPosition = player.position;
        this.gameObject.transform.transform.localRotation = player.rotation;

        Particulas.transform.position = player.position;
    }
}
