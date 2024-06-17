using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_AN : GameCTRL
{
    [SerializeField]
    Transform initialLobbySpawn;
    [SerializeField]
    Transform archivosNuevosSpawn;

    [SerializeField]
    GameObject playerPrefab;

    bool spawn = false;

    void Awake()
    {
        if (rooms == 1) // Archivos Nuevos
        {
            GameObject player = Instantiate(playerPrefab, archivosNuevosSpawn.position, archivosNuevosSpawn.rotation);
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