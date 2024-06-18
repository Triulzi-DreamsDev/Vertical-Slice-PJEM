using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameCTRL
{
    [SerializeField]
    Transform initialLobbySpawn;
    [SerializeField]
    Transform archivosNuevosSpawn;
    [SerializeField]
    Transform archivosViejosSpawn;
    [SerializeField]
    Transform oficinaBossSpawn;
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    GameObject pb;

    bool spawn = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (rooms == 0) //Lobby
        {
            GameObject player = Instantiate(playerPrefab, initialLobbySpawn.position, initialLobbySpawn.rotation);
}
        
        else if (rooms == 1) //Archivos Nuevos
        {
            GameObject player = Instantiate(playerPrefab, archivosNuevosSpawn.position, archivosNuevosSpawn.rotation);
        }
        else if (rooms == 2) //Archivos Viejos
        {
            GameObject player = Instantiate(playerPrefab, archivosViejosSpawn.position, archivosViejosSpawn.rotation);
        }
        else if (rooms == 3) // Oficina Jefe
        {
            GameObject player = Instantiate(playerPrefab, oficinaBossSpawn.position, oficinaBossSpawn.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
