using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    GameObject cameraM;

    private Transform trans;
    private Vector3 offset = new Vector3(0, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        // trans = cameraM.transform;
        cameraM = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
        trans = cameraM.transform;
        transform.LookAt(trans);
        transform.Rotate(offset);
    }
}
