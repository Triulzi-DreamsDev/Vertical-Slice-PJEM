using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBoss : MonoBehaviour
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
    }
}
