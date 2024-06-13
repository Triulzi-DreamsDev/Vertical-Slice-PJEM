using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisappearBoss : GameCTRL
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Boss")
        {
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "Player")
        {
            rooms = 0;
            SceneManager.LoadScene("Officina");
        }
    }
}
