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
    GameObject AN;
    [SerializeField]
    GameObject AV;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject player = null;

        if (rooms == 0) //Lobby
        {
            player = Instantiate(playerPrefab, initialLobbySpawn.position, initialLobbySpawn.rotation);
        }
        else if (rooms == 1) //Archivos Nuevos
        {
            player = Instantiate(playerPrefab, archivosNuevosSpawn.position, archivosNuevosSpawn.rotation);
            q = 3;
        }
        else if (rooms == 2) //Archivos Viejos
        {
            player = Instantiate(playerPrefab, archivosViejosSpawn.position, archivosViejosSpawn.rotation);
            q = 2;
        }
        else if (rooms == 3) // Oficina Jefe
        {
            player = Instantiate(playerPrefab, oficinaBossSpawn.position, oficinaBossSpawn.rotation);
        }

        // Desactivar objetos según el valor de q
        AN.SetActive(q != 2);
        AV.SetActive(q != 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}