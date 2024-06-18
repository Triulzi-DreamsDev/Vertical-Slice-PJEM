using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_AV : GameCTRL
{
    [SerializeField]
    Transform initialLobbySpawn;
    [SerializeField]
    Transform archivosViejosSpawn;

    [SerializeField]
    GameObject playerPrefab;

    bool spawn = false;

    void Awake()
    {
        if (rooms == 2) // Archivos Viejos
        {
            GameObject player = Instantiate(playerPrefab, archivosViejosSpawn.position, archivosViejosSpawn.rotation);
            q = 1;
        }
        else if (rooms == 0) // Lobby
        {
            GameObject player = Instantiate(playerPrefab, initialLobbySpawn.position, initialLobbySpawn.rotation);
        }
    }

    void Update()
    {
    }
}
