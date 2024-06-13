using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{
    Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
        float dist = Vector3.Distance(target.position, transform.position);
        print(offset);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + new Vector3(-7.95f, 6.75f, -7.11f);
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
