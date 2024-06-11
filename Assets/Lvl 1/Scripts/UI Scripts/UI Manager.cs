using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : GameCTRL
{
    [SerializeField] private TextMeshProUGUI playerNameUI;
    // Start is called before the first frame update
    void Start()
    {
        playerNameUI.text = nameOfPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
