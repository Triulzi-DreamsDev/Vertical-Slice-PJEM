using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanLobbyManager : GameCTRL
{

    [SerializeField]
    Transform initialLobbySpawn;
    [SerializeField]
    Transform level1;
    [SerializeField]
    Transform level2;
    [SerializeField]
    GameObject playerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        if (level == 0)
        {
            GameObject player = Instantiate(playerPrefab, initialLobbySpawn.position, initialLobbySpawn.rotation);
        }
        else if (level == 1)
        {
            GameObject player = Instantiate(playerPrefab, level1.position, level1.rotation);
        }
        else if (level == 2)
        {
            GameObject player = Instantiate(playerPrefab, level2.position, level2.rotation);
        }
        else
        {
            print("no encuentro ese nivel" + level);
        }
    }
}
