using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escritorio : MonoBehaviour
{
    [SerializeField]
    BossBehavior bossBehavior;

    // Start is called before the first frame update
    void Start()
    {
       // bossBehavior = GetComponent<BossBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Escritorio")
        {
            print("Boss collision");
            bossBehavior.cajon = true;
        }
    }
}
