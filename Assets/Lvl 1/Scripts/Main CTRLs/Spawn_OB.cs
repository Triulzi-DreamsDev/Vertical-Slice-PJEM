using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_OB : GameCTRL
{
    [SerializeField]
    Transform initialLobbySpawn;
    [SerializeField]
    Transform oficinaSpawn;
    [SerializeField]
    Transform oficinaBossSpawn;

    [SerializeField]
    GameObject playerPrefab;

    bool spawn = false;

    void Awake()
    {
        if (rooms == 3) // Oficina Jefe
        {
            GameObject player = Instantiate(playerPrefab, oficinaBossSpawn.position, oficinaBossSpawn.rotation);
        }
        else if (rooms == 0) // Lobby
        {
            GameObject player = Instantiate(playerPrefab, initialLobbySpawn.position, initialLobbySpawn.rotation);
        }
        else if (rooms == 4) // Entrada Oficina
        {
            GameObject player = Instantiate(playerPrefab, oficinaSpawn.position, oficinaSpawn.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
